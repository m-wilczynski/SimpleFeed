namespace SimpleFeed.Data.Queries
{
    using System.Linq;
    using Core.FeedEntries.Base;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using OperationInputs;
    using OperationResults;
    using OperationResults.ValidationResults;
    using _Base;

    public class GetAllEntries : EfQuery<PaginatedResult<FeedEntryBase>>
    {
        public PaginationRequest PaginationRequest { get; set; }

        public GetAllEntries(IConfiguration configuration) : base(configuration)
        {
        }

        protected override PaginatedResult<FeedEntryBase> ExecuteInternal()
        {
            var totalPages = (uint)Context.FeedEntries.AsNoTracking().Count();
            var mappedResult = Context.FeedEntries.AsNoTracking().WithNavigationProperties()
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
