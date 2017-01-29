namespace SimpleFeed.Data.Commands.User
{
    using System;
    using Base;
    using Configuration;
    using Core.User;
    using Microsoft.EntityFrameworkCore;
    using OperationResults.ValidationResults;

    public class UpdateUserDetails : EfCommand
    {
        public UpdateUserDetails(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public Guid UserId { get; set; }
        public string Description { get; set; }

        protected override void ExecuteInternal()
        {
            var user = Context.Users.Find(UserId);
            if (!string.IsNullOrEmpty(Description)) user.UserDescription = Description;

            Context.Entry(user).State = EntityState.Modified;
            Context.SaveChanges();
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UserId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UserId));
            if (Context.Users.Find(UserId) == null)
                return new NotFoundValidationResult<ApplicationUser>(UserId);
            return new PassedValidationResult();
        }
    }
}
