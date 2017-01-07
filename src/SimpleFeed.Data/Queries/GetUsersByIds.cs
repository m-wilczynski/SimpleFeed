namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.User;
    using Microsoft.EntityFrameworkCore;
    using OperationResults.ValidationResults;

    public class GetUsersByIds : EfQuery<ICollection<ApplicationUser>>
    {
        public ICollection<Guid> IdsToMatch { get; set; }

        public GetUsersByIds(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        protected override ICollection<ApplicationUser> ExecuteInternal()
        {
            return Context.Set<ApplicationUser>().AsNoTracking()
                .Where(usr => IdsToMatch.Contains(usr.Id)).ToList(); ;
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (IdsToMatch == null || IdsToMatch.Any(id => id.Equals(Guid.Empty)))
                return new InvalidInputValidationResult(nameof(IdsToMatch));
            return new PassedValidationResult();
        }
    }
}
