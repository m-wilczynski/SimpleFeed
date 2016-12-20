namespace SimpleFeed.Core.Interactions
{
    using System;
    using System.Collections.Generic;
    using FeedEntries.Base;

    public class FeedEntryComment : ModelBase
    {
        public readonly FeedEntryBase CommentedEntry;
        public readonly string Comment;

        private readonly Dictionary<Guid, CommentVote> _votes = new Dictionary<Guid, CommentVote>();
        private readonly HashSet<Guid> _voters = new HashSet<Guid>(); 

        public FeedEntryComment(FeedEntryBase commentedEntry, string comment, Guid? id = null) : base(id)
        {
            if (commentedEntry == null)
                throw new ArgumentNullException(nameof(commentedEntry));
            if (string.IsNullOrEmpty(comment))
                throw new ArgumentNullException(nameof(comment));

            CommentedEntry = commentedEntry;
            Comment = comment;
        }

        public Dictionary<Guid, CommentVote> Votes => new Dictionary<Guid, CommentVote>(_votes);

        public CommentVote GetVote(Guid commentId)
        {
            if (!_votes.ContainsKey(commentId)) return null;
            return _votes[commentId];
        }

        public CommentVote MakeVote(bool isPositive, Guid voterId, Guid? voteId = null)
        {
            if (voteId != null && _votes.ContainsKey(voteId.Value)) return null;
            if (_voters.Contains(voterId)) return null;

            var voteEntry = new CommentVote(this, isPositive, voterId, voteId);

            _votes.Add(voteEntry.Id, voteEntry);
            _voters.Add(voterId);
            return voteEntry;
        }

        public bool RemoveVote(Guid commentId)
        {
            if (!_votes.ContainsKey(commentId)) return false;

            _voters.Remove(_votes[commentId].Creator.Value);
            _votes.Remove(commentId);
            return true;
        }
    }
}
