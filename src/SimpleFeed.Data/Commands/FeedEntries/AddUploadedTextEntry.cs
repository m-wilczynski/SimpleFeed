namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Base;
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using Microsoft.Extensions.Configuration;
    using OperationResults.ValidationResults;

    public class AddUploadedTextEntry : EfCommand
    {
        public AddUploadedTextEntry(IConfiguration configuration) : base(configuration)
        {
        }

        public UploadedTextFeedEntry UploadedText { get; set; }

        protected override void ExecuteInternal()
        {
            Context.AddAndSave(UploadedText.AsEntity());
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UploadedText == null)
                return new InvalidInputValidationResult(nameof(UploadedText));
            return new PassedValidationResult();
        }
    }
}
