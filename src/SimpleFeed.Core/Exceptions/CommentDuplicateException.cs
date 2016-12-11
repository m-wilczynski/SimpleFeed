namespace SimpleFeed.Core.Exceptions
{
    using System;

    public class CommentDuplicateException : Exception
    {
        public readonly Guid CommentIdentifier;

        public CommentDuplicateException(Guid commentId)
        {
            CommentIdentifier = commentId;
        }
    }
}
