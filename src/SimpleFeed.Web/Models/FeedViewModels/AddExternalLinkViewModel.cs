﻿namespace SimpleFeed.Models.FeedViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddExternalLinkViewModel
    {
        [Required]
        [RegularExpression(@"@^(https?)://[^\s/$.?#].[^\s]*$@iS")]
        public string LinkAddress { get; set; }
    }


}