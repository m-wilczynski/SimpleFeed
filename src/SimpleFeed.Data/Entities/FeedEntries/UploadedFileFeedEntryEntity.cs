namespace SimpleFeed.Data.Entities.FeedEntries
{
    using System;

    internal class UploadedFileFeedEntryEntity : FeedEntryEntity
    {
        public string RelativeFilePath { get; set; }
    }
}
