namespace SimpleFeed.Core.Interactions
{
    using System;
    using System.Collections.Generic;
    using FeedEntries;

    public class FeedEntryComment : ModelBase
    {
        public readonly FeedEntryBase CommentedEntry;
        public readonly string Comment;

        private readonly Dictionary<Guid, CommentVote> _votes = new Dictionary<Guid, CommentVote>();

        public FeedEntryComment(FeedEntryBase commentedEntry, string comment, Guid? id = null) : base(id)
        {
            if (commentedEntry == null)
                throw new ArgumentNullException(nameof(commentedEntry));
            if (string.IsNullOrEmpty(comment))
                throw new ArgumentNullException(nameof(comment));

            CommentedEntry = commentedEntry;
            Comment = comment;
        }

        public CommentVote GetVote(Guid commentId)
        {
            if (!_votes.ContainsKey(commentId)) return null;
            return _votes[commentId];
        }

        public CommentVote MakeVote(bool isPositive, Guid voterId, Guid? commentId = null)
        {
            if (commentId != null && _votes.ContainsKey(commentId.Value)) return null;
            var commentEntry = new CommentVote(this, isPositive, voterId, commentId);
            _votes.Add(commentEntry.Id, commentEntry);
            return commentEntry;
        }

        public bool RemoveVote(Guid commentId)
        {
            if (!_votes.ContainsKey(commentId)) return false;
            _votes.Remove(commentId);
            return true;
        }
    }
}
