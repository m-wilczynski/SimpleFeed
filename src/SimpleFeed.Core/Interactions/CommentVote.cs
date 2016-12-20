using System;

namespace SimpleFeed.Core.Interactions
{
    public class CommentVote : ModelBase
    {
        public readonly FeedEntryComment VotedComment;
        public bool IsPositive;

        public CommentVote(FeedEntryComment votedComment, bool isPositive, Guid creatorId, Guid? id = default(Guid?)) : base(id)
        {
            if (votedComment == null)
                throw new ArgumentNullException(nameof(votedComment));
            if (creatorId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(creatorId));

            VotedComment = votedComment;
            IsPositive = isPositive;
            Creator = creatorId;
        }
    }
}
