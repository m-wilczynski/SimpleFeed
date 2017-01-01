namespace SimpleFeed.Data.Queries
{
    using System;
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

    public class GetUserEntries : EfQuery<PaginatedResult<FeedEntryBase>>
    {
        public GetUserEntries(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public PaginationRequest PaginationRequest { get; set; }
        public DateCreatedOrder? DateCreatedOrder { get; set; }
        public Guid UserIdentifier { get; set; }

        protected override PaginatedResult<FeedEntryBase> ExecuteInternal()
        {
            var query = Context.FeedEntries.AsNoTracking().Where(fe => fe.CreatorId.Equals(UserIdentifier));
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
            if (UserIdentifier.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UserIdentifier));
            return new PassedValidationResult();
        }
    }
}
