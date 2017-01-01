namespace SimpleFeed.Models.FeedViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class AddUploadedImageViewModel : AddFeedEntryViewModel
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
