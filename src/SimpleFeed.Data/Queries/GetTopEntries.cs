namespace SimpleFeed.Data.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using OperationResults;
    using OperationResults.ValidationResults;

    public class GetTopEntries : EfQuery<ICollection<ModelWithCreator<FeedEntryBase>>>
    {
        public GetTopEntries(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public uint HowMany { get; set; }

        protected override ICollection<ModelWithCreator<FeedEntryBase>> ExecuteInternal()
        {
            var query = Context.FeedEntries.AsNoTracking();

            var mappedResult = query.WithCreatorIncluded().WithNavigationProperties()
                .OrderByDescending(e => e.Votes.Sum(v => v.IsPositive ? 1 : -1))
                .Take((int)HowMany)
                .ToList().Select(e => e.AsDomainModelResolvedWithCreator()).ToList();

            return mappedResult;
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            return new PassedValidationResult();
        }
    }
}
