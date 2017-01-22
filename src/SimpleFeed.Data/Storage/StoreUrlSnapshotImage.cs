namespace SimpleFeed.Data.Storage
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Base;
    using Configuration;
    using OperationResults.ValidationResults;

    public class StoreUrlSnapshotImage : StorageCommand
    {
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }
        public HttpResponseMessage Image { get; set; }

        public StoreUrlSnapshotImage(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        protected override async Task<string> ExecuteInternalAsync()
        {
            var path = Configuration.GetAbsolutePathForUserContent(UserId);
            Directory.CreateDirectory(path);
            var fileName = $"{EntryId.ToString().Replace("-", "")}.jpg";
            var finalPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(finalPath, FileMode.CreateNew))
            {
                await Image.Content.CopyToAsync(stream);
            }

            return Path.Combine(Configuration.GetRelativePathForUserContent(UserId), fileName).Replace(@"\", "/");
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UserId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UserId));
            if (EntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(EntryId));
            if (Image == null)
                return new InvalidInputValidationResult(nameof(Image));
            if (!Image.IsSuccessStatusCode)
                return new InvalidInputValidationResult(nameof(Image));
            if (!Image.Content.Headers.ContentType.MediaType.Contains("image"))
                return new InvalidInputValidationResult(nameof(Image));
            return new PassedValidationResult();
        }
    }
}
