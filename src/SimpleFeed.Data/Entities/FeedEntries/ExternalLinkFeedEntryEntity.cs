namespace SimpleFeed.Data.Entities.FeedEntries
{
    using System;

    internal class ExternalLinkFeedEntryEntity : FeedEntryEntity
    {
        public Uri LinkAddress { get; set; }
    }
}
