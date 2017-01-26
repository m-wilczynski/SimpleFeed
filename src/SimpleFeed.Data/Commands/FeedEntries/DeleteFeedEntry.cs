namespace SimpleFeed.Data.Commands.FeedEntries
{
    using System;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using Entities.FeedEntries;
    using EntityFramework.CommonOperations;
    using OperationResults.ValidationResults;

    public class DeleteFeedEntry : EfCommand
    {
        public DeleteFeedEntry(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public Guid EntryId { get; set; }

        protected override void ExecuteInternal()
        {
            Context.DeleteAndSave<FeedEntryEntity>(EntryId);
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (EntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(EntryId));
            return new PassedValidationResult();
        }
    }
}
