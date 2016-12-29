namespace SimpleFeed.Models.FeedViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Extensions.FileProviders;

    public class AddUploadedImageViewModel
    {
        [Required]
        public IFileInfo Image { get; set; }
    }
}
