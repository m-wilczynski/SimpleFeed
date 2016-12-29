namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Base;
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using OperationResults.ValidationResults;

    public class UpdateUploadedTextEntry : EfCommand
    {
        public UpdateUploadedTextEntry(string mySqlConnectionString) : base(mySqlConnectionString)
        {
        }

        public UploadedTextFeedEntry UploadedText { get; set; }

        protected override void ExecuteInternal()
        {
            Context.UpdateAndSave(UploadedText.AsEntity());
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UploadedText == null)
                return new InvalidInputValidationResult(nameof(UploadedText));
            return new PassedValidationResult();
        }
    }
}
