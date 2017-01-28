namespace SimpleFeed.Models.FeedViewModels
{
    using System;

    public class AddExternalLinkResultViewModel : AjaxRequestResult
    {
        public Guid EntryId { get; set; }
    }
}
