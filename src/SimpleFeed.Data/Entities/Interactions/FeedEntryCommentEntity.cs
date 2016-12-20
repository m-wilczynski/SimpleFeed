namespace SimpleFeed.Data.Entities.Interactions
{
    using System.Collections.Generic;
    using FeedEntries;

    internal class FeedEntryCommentEntity
    {
        public string Comment { get; set; }
        public FeedEntryEntity CommentedEntity { get; set; }
        public List<CommentVoteEntity> Votes { get; set; }
    }
}
