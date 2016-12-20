namespace SimpleFeed.Data.Mappings.Interactions
{
    using Core.Interactions;
    using Entities.Interactions;

    internal static class CommentVoteMapping
    {
        public static CommentVoteEntity AsEntity(this CommentVote model, FeedEntryCommentEntity parent)
        {
            return new CommentVoteEntity
            {
                Id = model.Id,
                CreationDate = model.CreationDate,
                CreatorId = model.Creator.Value,
                IsPositive = model.IsPositive,
                VotedComment = parent
            };
        }
    }
}
