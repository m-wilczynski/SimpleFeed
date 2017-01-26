namespace SimpleFeed.Models.FeedViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdateFeedEntryViewModel
    {
        [Required]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
