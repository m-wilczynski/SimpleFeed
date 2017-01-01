namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Base;
    using Configuration;
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using OperationResults.ValidationResults;

    public class UpdateUploadedTextEntry : EfCommand
    {
        public UpdateUploadedTextEntry(IPersistenceConfiguration configuration) : base(configuration)
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
