namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using OperationResults;
    using OperationResults.ValidationResults;

    public class GetEntryById : EfQuery<ModelWithCreator<FeedEntryBase>>
    {
        public GetEntryById(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public Guid EntryId { get; set; }

        protected override ModelWithCreator<FeedEntryBase> ExecuteInternal()
        {
            return Context.FeedEntries.WithNavigationProperties().WithCreatorIncluded()
                .SingleOrDefault(e => e.Id.Equals(EntryId)).AsDomainModelResolvedWithCreator();                
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (EntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(EntryId));
            return new PassedValidationResult();
        }
    }
}
