namespace SimpleFeed.Data.Storage
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Configuration;
    using Microsoft.AspNetCore.Http;
    using OperationResults.ValidationResults;

    public class StoreUploadedFeedImage : StorageCommand
    {
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }

        public StoreUploadedFeedImage(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        protected override async Task<string> ExecuteInternalAsync()
        {
            var path = Configuration.GetAbsolutePathForUserContent(UserId);
            Directory.CreateDirectory(path);
            var fileName = Path.GetFileName(Image.FileName);
            fileName = $"{Guid.NewGuid().ToString().Replace("-", "")}.{fileName.Split('.').Last()}";
            var finalPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(finalPath, FileMode.CreateNew))
            {
                await Image.CopyToAsync(stream);
            }

            return Path.Combine(Configuration.GetRelativePathForUserContent(UserId), fileName).Replace(@"\", "/");
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UserId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UserId));
            if (Image == null)
                return new InvalidInputValidationResult(nameof(Image));
            if (Configuration.ImageFiletypes.All(filetype => 
                !filetype.Equals(Image.FileName.Split('.').Last(), StringComparison.CurrentCultureIgnoreCase)))
                return new InvalidInputValidationResult(nameof(Image));
            return new PassedValidationResult();
        }
    }
}
