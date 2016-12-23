﻿namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using OperationResults.ValidationResults;
    using _Base;

    public class AddUploadedTextEntry : EfCommand
    {
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