using System;

namespace SimpleFeed.Core.Interactions
{
    using FeedEntries.Base;

    public class FeedEntryVote : ModelBase
    {
        public readonly FeedEntryBase VotedEntry;
        public bool IsPositive;

        public FeedEntryVote(FeedEntryBase votedEntry, bool isPositive, Guid creatorId, Guid? id = default(Guid?)) : base(id)
        {
            if (votedEntry == null)
                throw new ArgumentNullException(nameof(votedEntry));
            if (creatorId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(creatorId));

            VotedEntry = votedEntry;
            IsPositive = isPositive;
            Creator = creatorId;
        }
    }
}
