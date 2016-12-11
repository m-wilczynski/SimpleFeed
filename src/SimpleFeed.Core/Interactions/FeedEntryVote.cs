using System;
using SimpleFeed.Core.FeedEntries;

namespace SimpleFeed.Core.Interactions
{
    public class FeedEntryVote : ModelBase
    {
        public readonly FeedEntryBase FeedEntry;
        public bool IsPositive;

        public FeedEntryVote(FeedEntryBase feedEntry, bool isPositive, Guid creatorId, Guid? id = default(Guid?)) : base(id)
        {
            if (feedEntry == null)
                throw new ArgumentNullException(nameof(feedEntry));
            if (creatorId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(creatorId));

            FeedEntry = feedEntry;
            IsPositive = isPositive;
        }
    }
}
