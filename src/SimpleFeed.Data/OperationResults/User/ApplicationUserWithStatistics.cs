namespace SimpleFeed.Data.OperationResults.User
{
    using System;
    using Core.User;

    public class ApplicationUserWithStatistics
    {
        public readonly ApplicationUser User;
        public readonly uint EntriesCreated;
        public readonly uint VotesMade;

        public ApplicationUserWithStatistics(ApplicationUser user, uint entriesCreated, uint votesMade)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            User = user;
            EntriesCreated = entriesCreated;
            VotesMade = votesMade;
        }
    }
}
