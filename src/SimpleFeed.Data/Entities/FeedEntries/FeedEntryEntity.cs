namespace SimpleFeed.Data.Entities.FeedEntries
{
    using System.Collections.Generic;
    using Interactions;

    internal abstract class FeedEntryEntity : EntityBase
    {
        public bool IsPublished { get; set; }
        public List<FeedEntryCommentEntity> Comments { get; set; }
        public List<FeedEntryVoteEntity> Votes { get; set; }
    }
}
