namespace SimpleFeed.Data.Entities.FeedEntries
{
    using System;

    internal class UploadedFileFeedEntryEntity : FeedEntryEntity
    {
        public Uri RelativeFilePath { get; set; }
    }
}
