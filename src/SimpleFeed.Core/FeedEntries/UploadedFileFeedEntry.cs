using System;

namespace SimpleFeed.Core.FeedEntries
{
    using Base;
    using Exceptions;

    public class UploadedFileFeedEntry : FeedEntryBase
    {
        private Uri _relativeFilePath;

        public UploadedFileFeedEntry(Uri relativeFilePath, Guid creatorId, Guid? id = default(Guid?)) : base(creatorId, id)
        {
            if (relativeFilePath == null)
                throw new ArgumentNullException(nameof(relativeFilePath));
            if (!ValidateFileAddress(relativeFilePath))
                throw new InvalidUriException(relativeFilePath, "Invalid relative address of file");
        }

        public Uri RelativeFilePath
        {
            get { return _relativeFilePath; }
            set
            {
                if (!ValidateFileAddress(value)) throw new InvalidUriException(value, "Invalid relative address of file");
                _relativeFilePath = value;
            }
        }

        public static bool ValidateFileAddress(Uri link)
        {
            return link != null && !link.IsAbsoluteUri;
        }
    }
}
