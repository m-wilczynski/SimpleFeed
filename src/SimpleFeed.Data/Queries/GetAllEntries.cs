namespace SimpleFeed.Data.Queries
{
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using EntityFramework.CommonOperations;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using OperationInputs;
    using OperationResults;
    using OperationResults.ValidationResults;

    public class GetAllEntries : EfQuery<PaginatedResult<ModelWithCreator<FeedEntryBase>>>
    {
        public GetAllEntries(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public PaginationRequest PaginationRequest { get; set; }
        public DateCreatedOrder? DateCreatedOrder { get; set; }

        protected override PaginatedResult<ModelWithCreator<FeedEntryBase>> ExecuteInternal()
        {
            var query = Context.FeedEntries.AsNoTracking();
            query.OrderedByDateCreated(DateCreatedOrder);

            var totalPages = (uint)query.Count();
            var mappedResult = query.WithCreatorIncluded().WithNavigationProperties()
                .Skip((int)((PaginationRequest.Page - 1) * PaginationRequest.PageSize)).Take((int)PaginationRequest.PageSize)
                .Select(e => e.AsDomainModelResolvedWithCreator()).ToList();

            return new PaginatedResult<ModelWithCreator<FeedEntryBase>>(mappedResult, new PaginationInfo(totalPages, PaginationRequest));
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (PaginationRequest == null)
                return new NoPaginationProvidedValidationResult();
            return new PassedValidationResult();
        }
    }
}
