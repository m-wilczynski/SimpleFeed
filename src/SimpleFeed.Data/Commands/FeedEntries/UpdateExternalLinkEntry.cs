﻿namespace SimpleFeed.Data.Commands.FeedEntries
{
    using Base;
    using Configuration;
    using Core.FeedEntries;
    using EntityFramework.CommonOperations;
    using Mappings.FeedEntries;
    using OperationResults.ValidationResults;

    public class UpdateExternalLinkEntry : EfCommand
    {
        public UpdateExternalLinkEntry(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public ExternalLinkFeedEntry ExternalLink { get; set; }

        protected override void ExecuteInternal()
        {
            Context.UpdateAndSave(ExternalLink.AsEntity());
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (ExternalLink == null)
                return new InvalidInputValidationResult(nameof(ExternalLink));
            return new PassedValidationResult();
        }
    }
}
