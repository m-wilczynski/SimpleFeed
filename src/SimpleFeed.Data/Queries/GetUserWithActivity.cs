namespace SimpleFeed.Data.Queries
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using OperationResults.User;
    using OperationResults.ValidationResults;

    public class GetUserWithActivity : EfQuery<ApplicationUserWithFeedActivity>
    {
        public Guid UserId { get; set; }

        public GetUserWithActivity(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        protected override ApplicationUserWithFeedActivity ExecuteInternal()
        {
            var user = Context.Users.Find(UserId);
            if (user == null) return null;

            var feedEntries = Context.FeedEntries.AsNoTracking().Where(fe => fe.CreatorId.Equals(UserId))
                .Select(fe => fe.AsDomainModelResolved()).ToList();

            var votes = Context.FeedEntryVotes.AsNoTracking().Where(fev => fev.CreatorId.Equals(UserId))
                .WithNavigationProperties()
                .ToList();

            return new ApplicationUserWithFeedActivity(user)
            {
                EntriesCreated = feedEntries,
                //Done this way because Select combined with Includes just doesn't seem to work...
                VotesMade = votes.Select(fev => fev.VotedEntry.AsDomainModelResolved().Votes[fev.Id]).ToList()
            };
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UserId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UserId));
            return new PassedValidationResult();
        }
    }
}
