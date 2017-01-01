using System;

namespace SimpleFeed.Core.FeedEntries
{
    using System.IO;
    using Base;
    using Exceptions;

    public class UploadedImageFeedEntry : FeedEntryBase
    {
        private string _relativeFilePath;

        public UploadedImageFeedEntry(string relativeFilePath, string title, Guid creatorId, Guid? id = default(Guid?)) : base(title, creatorId, id)
        {
            RelativeFilePath = relativeFilePath;
        }

        public string RelativeFilePath
        {
            get { return _relativeFilePath; }
            set
            {
                if (!ValidateFileAddress(value)) throw new InvalidPathException(value, "Invalid relative address of file");
                _relativeFilePath = value;
            }
        }

        public static bool ValidateFileAddress(string path)
        {
            return !string.IsNullOrEmpty(path) && Uri.IsWellFormedUriString(path, UriKind.Relative) &&
                   !Path.IsPathRooted(path);
        }
    }
}
