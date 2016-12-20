namespace SimpleFeed.Data
{
    using System;
    using SimpleFeed.Core.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class SimpleFeedContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public SimpleFeedContext(DbContextOptions<SimpleFeedContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
