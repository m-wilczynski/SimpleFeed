namespace SimpleFeed.Core.User
{
    using System;
    using System.Collections;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
        public DateTime RegistrationDate { get; set; }
        public string UserDescription { get; set; }
    }
}
