namespace SimpleFeed.Models.VoteViewModels
{
    using System;

    public class MakeVoteResultViewModel : AjaxRequestResult
    {
        public MakeVoteResultViewModel()
        {
            Success = true;
        }

        public bool Upvote { get; set; }
        public int NewVoteBalance { get; set; }
        public Guid VotedEntry { get; set; }
    }
}
