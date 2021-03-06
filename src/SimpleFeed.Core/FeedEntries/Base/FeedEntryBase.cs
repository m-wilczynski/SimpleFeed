﻿namespace SimpleFeed.Core.FeedEntries.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interactions;

    public abstract class FeedEntryBase : ModelBase
    {
        private readonly Dictionary<Guid, FeedEntryComment> _comments = new Dictionary<Guid, FeedEntryComment>();
        private readonly Dictionary<Guid, FeedEntryVote> _votes = new Dictionary<Guid, FeedEntryVote>();
        private readonly HashSet<Guid> _voters = new HashSet<Guid>();
        private string _title;

        protected FeedEntryBase(string title, Guid creatorId, Guid? id = null) : base(id)
        {
            if (creatorId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(creatorId));
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            Creator = creatorId;
            Title = title;
        }

        public bool IsPublished { get; set; }
        public string Description { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Title));
                _title = value;
            }
        }

        public Dictionary<Guid, FeedEntryComment> Comments => new Dictionary<Guid, FeedEntryComment>(_comments);
        public Dictionary<Guid, FeedEntryVote> Votes => new Dictionary<Guid, FeedEntryVote>(_votes);

        public int VotesBalance => _votes.Values.Sum(vote => vote.IsPositive ? 1 : -1);

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

        public FeedEntryVote MakeVote(bool isPositive, Guid voterId, Guid? voteId = null)
        {
            if (voteId != null && _votes.ContainsKey(voteId.Value)) return null;
            if (_voters.Contains(voterId)) return null;

            var vote = new FeedEntryVote(this, isPositive, voterId, voteId);

            _votes.Add(vote.Id, vote);
            _voters.Add(vote.Creator.Value);
            return vote;
        }

        public bool RemoveVote(Guid voteId)
        {
            if (!_votes.ContainsKey(voteId)) return false;

            _voters.Remove(_votes[voteId].Creator.Value);
            _votes.Remove(voteId);
            return true;
        }
    }
}
