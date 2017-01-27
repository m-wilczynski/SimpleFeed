namespace SimpleFeed.Data.OperationResults.User
{
    using System;
    using System.Collections.Generic;
    using Core.FeedEntries.Base;
    using Core.Interactions;
    using Core.User;

    public class ApplicationUserWithFeedActivity
    {
        public readonly ApplicationUser User;

        public ApplicationUserWithFeedActivity(ApplicationUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            User = user;
        }

        public ICollection<FeedEntryBase> EntriesCreated { get; set; }
        public ICollection<FeedEntryVote> VotesMade { get; set; }
    }
}
