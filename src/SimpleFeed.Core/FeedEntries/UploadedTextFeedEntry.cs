namespace SimpleFeed.Core.FeedEntries
{
    using System;
    using Base;
    using Exceptions;

    public class UploadedTextFeedEntry : FeedEntryBase
    {
        private string _content;

        public UploadedTextFeedEntry(string content, string title, Guid creatorId, Guid? id = default(Guid?)) : base(title, creatorId, id)
        {
            Content = content;
        }

        public string Content
        {
            get { return _content; }
            set
            {
                if (!ValidateContent(value)) throw new InvalidEntryContentException(value, "Provided text content was invalid");
                _content = value;
            }
        }

        public static bool ValidateContent(string content)
        {
            if (string.IsNullOrEmpty(content)) return false;
            if (content.Length < 30) return false;
            return true;
        }
    }
}
