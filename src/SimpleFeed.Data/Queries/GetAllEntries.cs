namespace SimpleFeed.Data.Queries
{
    using System.Linq;
    using Base;
    using Core.FeedEntries.Base;
    using EntityFramework.CommonOperations;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using OperationInputs;
    using OperationResults;
    using OperationResults.ValidationResults;

    public class GetAllEntries : EfQuery<PaginatedResult<FeedEntryBase>>
    {
        public PaginationRequest PaginationRequest { get; set; }
        public DateCreatedOrder? DateCreatedOrder { get; set; }

        public GetAllEntries(string mySqlConnectionString) : base(mySqlConnectionString)
        {
        }

        protected override PaginatedResult<FeedEntryBase> ExecuteInternal()
        {
            var query = Context.FeedEntries.AsNoTracking();
            query.OrderedByDateCreated(DateCreatedOrder);

            var totalPages = (uint)query.Count();
            var mappedResult = query.WithNavigationProperties()
                .Skip((int)((PaginationRequest.Page - 1) * PaginationRequest.PageSize)).Take((int)PaginationRequest.PageSize)
                .Select(e => e.AsDomainModelResolved()).ToList();

            return new PaginatedResult<FeedEntryBase>(mappedResult, new PaginationInfo(totalPages, PaginationRequest));
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (PaginationRequest == null)
                return new NoPaginationProvidedValidationResult();
            return new PassedValidationResult();
        }
    }
}
