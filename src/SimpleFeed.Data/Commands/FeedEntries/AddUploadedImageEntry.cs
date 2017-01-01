namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Base;
    using Configuration;
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using OperationResults.ValidationResults;

    public class AddUploadedImageEntry : EfCommand
    {
        public AddUploadedImageEntry(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public UploadedImageFeedEntry UploadedImageEntry { get; set; }

        protected override void ExecuteInternal()
        {
            Context.AddAndSave(UploadedImageEntry.AsEntity());
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
