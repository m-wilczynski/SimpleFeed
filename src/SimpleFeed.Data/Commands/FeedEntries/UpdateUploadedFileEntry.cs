namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using OperationResults.ValidationResults;
    using _Base;

    public class UpdateUploadedFileEntry : EfCommand
    {
        public UploadedFileFeedEntry UploadedFileEntry { get; set; }

        protected override void ExecuteInternal()
        {
            Context.UpdateAndSave(UploadedFileEntry.AsEntity());
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UploadedFileEntry == null)
                return new InvalidInputValidationResult(nameof(UploadedFileEntry));
            //TODO - check if uploaded file was really uploaded?
            return new PassedValidationResult();
        }
    }
}
