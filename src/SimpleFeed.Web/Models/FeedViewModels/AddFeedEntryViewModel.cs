namespace SimpleFeed.Models.FeedViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddFeedEntryViewModel
    {
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
    }
}
