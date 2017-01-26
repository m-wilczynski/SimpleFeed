namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using OperationResults.ValidationResults;

    public class CheckIfCanModifyEntry : EfQuery<bool>
    {
        public CheckIfCanModifyEntry(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }

        protected override bool ExecuteInternal()
        {
            var entry = Context.FeedEntries.SingleOrDefault(fe => fe.Id.Equals(EntryId));
            return entry != null && UserId.Equals(entry.CreatorId.Value);
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (EntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(EntryId));
            if (UserId.Equals(Guid.Empty))
                return new InvalidFiletypeValidationResult(nameof(UserId));
            return new PassedValidationResult();
        }
    }
}
