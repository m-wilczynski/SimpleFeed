namespace SimpleFeed.Data.Entities.Interactions
{
    using FeedEntries;

    internal class FeedEntryVoteEntity
    {
        public bool IsPositive { get; set; }
        public FeedEntryEntity VotedEntry { get; set; }
    }
}
