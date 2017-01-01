namespace SimpleFeed.Core.Exceptions
{
    using System;

    public class InvalidPathException : Exception
    {
        public readonly string Path;

        public InvalidPathException(string path, string message) : base(message)
        {
            Path = path;
        }
    }
}
