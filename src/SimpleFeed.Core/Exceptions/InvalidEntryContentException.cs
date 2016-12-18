namespace SimpleFeed.Core.Exceptions
{
    using System;

    public class InvalidEntryContentException : Exception
    {
        public readonly string Content;

        public InvalidEntryContentException(string content, string message) : base(message)
        {
            Content = content;
        }
    }
}
