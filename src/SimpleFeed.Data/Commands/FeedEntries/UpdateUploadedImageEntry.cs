namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Base;
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using Microsoft.Extensions.Configuration;
    using OperationResults.ValidationResults;

    public class UpdateUploadedImageEntry : EfCommand
    {
        public UpdateUploadedImageEntry(IConfiguration configuration) : base(configuration)
        {
        }

        public UploadedImageFeedEntry UploadedImageEntry { get; set; }

        protected override void ExecuteInternal()
        {
            Context.UpdateAndSave(UploadedImageEntry.AsEntity());
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UploadedImageEntry == null)
                return new InvalidInputValidationResult(nameof(UploadedImageEntry));
            //TODO - check if uploaded file was really uploaded?
            return new PassedValidationResult();
        }
    }
}
