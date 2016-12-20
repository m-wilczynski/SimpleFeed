namespace SimpleFeed.Data.Entities.Interactions
{
    internal class CommentVoteEntity : EntityBase
    {
        public bool IsPositive { get; set; }
        public FeedEntryCommentEntity  VotedComment { get; set; }
    }
}
