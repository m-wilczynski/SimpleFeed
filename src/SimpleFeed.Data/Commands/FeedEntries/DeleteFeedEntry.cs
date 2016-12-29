namespace SimpleFeed.Data.Commands.FeedEntries
{
    using System;
    using Base;
    using Core.FeedEntries.Base;
    using EntityFramework.CommonOperations;
    using OperationResults.ValidationResults;

    public class DeleteFeedEntry<TEntry> : EfCommand where TEntry : FeedEntryBase
    {
        public DeleteFeedEntry(string mySqlConnectionString) : base(mySqlConnectionString)
        {
        }

        public Guid EntryId { get; set; }

        protected override void ExecuteInternal()
        {
            Context.DeleteAndSave(EntryId, typeof(TEntry));
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (EntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(EntryId));
            return new PassedValidationResult();
        }
    }
}
