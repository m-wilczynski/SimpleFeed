using System;

namespace SimpleFeed.Core.Interactions
{
    public class CommentVote : ModelBase
    {
        public readonly FeedEntryComment FeedEntry;
        public bool IsPositive;

        public CommentVote(FeedEntryComment feedEntry, bool isPositive, Guid creatorId, Guid? id = default(Guid?)) : base(id)
        {
            if (feedEntry == null)
                throw new ArgumentNullException(nameof(feedEntry));
            if (creatorId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(creatorId));

            FeedEntry = feedEntry;
            IsPositive = isPositive;
            Creator = creatorId;
        }
    }
}
