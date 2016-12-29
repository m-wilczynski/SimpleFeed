namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Core.Interactions;
    using EntityFramework.CommonOperations;
    using EntityFramework.EagerLoading;
    using Mappings.Interactions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using OperationInputs;
    using OperationResults;
    using OperationResults.ValidationResults;

    public class GetUserComments : EfQuery<PaginatedResult<FeedEntryComment>>
    {
        public PaginationRequest PaginationRequest { get; set; }
        public DateCreatedOrder? DateCreatedOrder { get; set; }
        public Guid UserIdentifier { get; set; }

        public GetUserComments(IConfiguration configuration) : base(configuration)
        {
        }

        protected override PaginatedResult<FeedEntryComment> ExecuteInternal()
        {
            var query = Context.Comments.AsNoTracking().Where(fe => fe.CreatorId.Equals(UserIdentifier));
            query.OrderedByDateCreated(DateCreatedOrder);

            var totalPages = (uint)query.Count();
            var mappedResult = query.WithNavigationProperties()
                .Skip((int)((PaginationRequest.Page - 1) * PaginationRequest.PageSize)).Take((int)PaginationRequest.PageSize)
                .Select(e => e.AsDomainModel()).ToList();

            return new PaginatedResult<FeedEntryComment>(mappedResult, new PaginationInfo(totalPages, PaginationRequest));
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
