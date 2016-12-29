namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Core.FeedEntries.Base;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.Extensions.Configuration;
    using OperationResults.ValidationResults;

    public class GetEntryById : EfQuery<FeedEntryBase>
    {
        public Guid EntryId { get; set; }

        public GetEntryById(IConfiguration configuration) : base(configuration)
        {
        }

        protected override FeedEntryBase ExecuteInternal()
        {
            return Context.FeedEntries.WithNavigationProperties().SingleOrDefault(e => e.Id.Equals(EntryId)).AsDomainModelResolved();                
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (EntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(EntryId));
            return new PassedValidationResult();
        }
    }
}
