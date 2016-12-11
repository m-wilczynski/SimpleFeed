namespace SimpleFeed.Core.FeedEntries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interactions;

    public abstract class FeedEntryBase : ModelBase
    {
        private readonly Dictionary<Guid, FeedEntryComment> _comments = new Dictionary<Guid, FeedEntryComment>();
        private readonly Dictionary<Guid, FeedEntryVote> _votes = new Dictionary<Guid, FeedEntryVote>(); 

        protected FeedEntryBase(Guid? id = null) : base(id)
        {
        }

        public Dictionary<Guid, FeedEntryComment> Comments => new Dictionary<Guid, FeedEntryComment>(_comments);
        public Dictionary<Guid, FeedEntryVote> Votes => new Dictionary<Guid, FeedEntryVote>(_votes);

        public FeedEntryComment GetComment(Guid commentId)
        {
            if (!_comments.ContainsKey(commentId)) return null;
            return _comments[commentId];
        }

        public FeedEntryComment MakeComment(string comment, Guid? commentId = null)
        {
            if (commentId != null && _comments.ContainsKey(commentId.Value)) return null;
            var commentEntry = new FeedEntryComment(this, comment, commentId);
            _comments.Add(commentEntry.Id, commentEntry);
            return commentEntry;
        }

        public bool RemoveComment(Guid commentId)
        {
            if (!_comments.ContainsKey(commentId)) return false;
            _comments.Remove(commentId);
            return true;
        }

        public FeedEntryVote GetVote(Guid commentId)
        {
            if (!_votes.ContainsKey(commentId)) return null;
            return _votes[commentId];
        }

        public FeedEntryVote MakeVote(bool isPositive, Guid voterId, Guid? commentId = null)
        {
            if (commentId != null && _votes.ContainsKey(commentId.Value)) return null;
            var commentEntry = new FeedEntryVote(this, isPositive, voterId, commentId);
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
