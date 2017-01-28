namespace SimpleFeed.Data.Entities.Interactions
{
    using System;
    using FeedEntries;

    internal class FeedEntryVoteEntity : EntityBase
    {
        public bool IsPositive { get; set; }
        public FeedEntryEntity VotedEntry { get; set; }
        public Guid VotedEntryId { get; set; }
    }
}
