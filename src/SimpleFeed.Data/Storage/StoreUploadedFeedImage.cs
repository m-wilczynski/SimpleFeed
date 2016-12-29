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
        public IFormFile File { get; set; }

        public StoreUploadedFeedImage(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        protected override async Task<string> ExecuteInternalAsync()
        {
            using (var stream = new FileStream(Configuration.GetPathForUserContent(UserId), FileMode.CreateNew))
            {
                await File.CopyToAsync(stream);
            }
            return Path.Combine(Configuration.GetPathForUserContent(UserId), File.FileName);
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UserId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UserId));
            if (File == null)
                return new InvalidInputValidationResult(nameof(File));
            if (Configuration.ImageFiletypes.All(filetype => 
                !filetype.Equals(File.FileName.Split('.').Last(), StringComparison.CurrentCultureIgnoreCase)))
                return new InvalidInputValidationResult(nameof(File));
            return new PassedValidationResult();
        }
    }
}
