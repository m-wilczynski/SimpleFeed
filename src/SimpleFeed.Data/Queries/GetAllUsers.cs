namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using Core.User;
    using EntityFramework.CommonOperations;
    using EntityFramework.EagerLoading;
    using Microsoft.EntityFrameworkCore;
    using OperationInputs;
    using OperationResults;
    using OperationResults.ValidationResults;

    public class GetAllUsers : EfQuery<PaginatedResult<ApplicationUser>>
    {
        public GetAllUsers(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public PaginationRequest PaginationRequest { get; set; }

        protected override PaginatedResult<ApplicationUser> ExecuteInternal()
        {
            //var query = Context.Users.AsNoTracking();

            //var totalPages = (uint)Math.Ceiling((double)query.Count() / PaginationRequest.PageSize);
            //var mappedResult = query.OrderByDescending(ap => ap.UserName)
            //    .Skip((int)((PaginationRequest.Page - 1) * PaginationRequest.PageSize)).Take((int)PaginationRequest.PageSize)
            //    .Select(e => e.AsDomainModelResolvedWithCreator()).ToList();

            //return new PaginatedResult<ModelWithCreator<FeedEntryBase>>(mappedResult, new PaginationInfo(totalPages, PaginationRequest));
            return null;

        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (PaginationRequest == null)
                return new NoPaginationProvidedValidationResult();
            return new PassedValidationResult();
        }
    }
}
