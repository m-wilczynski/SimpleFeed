namespace SimpleFeed.Models.FeedViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.FileProviders;

    public class AddUploadedImageViewModel
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
