namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using Core.User;
    using Microsoft.EntityFrameworkCore;
    using OperationInputs;
    using OperationResults;
    using OperationResults.User;
    using OperationResults.ValidationResults;

    public class GetAllUsers : EfQuery<PaginatedResult<ApplicationUser>>
    {
        public GetAllUsers(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public PaginationRequest PaginationRequest { get; set; }

        protected override PaginatedResult<ApplicationUser> ExecuteInternal()
        {
            var query = Context.Users.AsNoTracking();

            var totalPages = (uint)Math.Ceiling((double)query.Count() / PaginationRequest.PageSize);
            var mappedResult = query.OrderByDescending(ap => ap.UserName)
                .Skip((int)((PaginationRequest.Page - 1) * PaginationRequest.PageSize)).Take((int)PaginationRequest.PageSize)
                .ToList();

            return new PaginatedResult<ApplicationUser>(mappedResult, new PaginationInfo(totalPages, PaginationRequest));
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (PaginationRequest == null)
                return new NoPaginationProvidedValidationResult();
            return new PassedValidationResult();
        }
    }
}
