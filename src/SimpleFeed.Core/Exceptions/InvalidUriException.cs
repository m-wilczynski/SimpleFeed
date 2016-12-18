namespace SimpleFeed.Core.Exceptions
{
    using System;

    public class InvalidUriException : Exception
    {
        public readonly Uri InvalidUri;

        public InvalidUriException(Uri invalidUri, string message) : base(message)
        {
            InvalidUri = invalidUri;
        }
    }
}
