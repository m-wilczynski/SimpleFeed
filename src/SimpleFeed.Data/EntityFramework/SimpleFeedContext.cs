namespace SimpleFeed.Data
{
    using System;
    using Entities.FeedEntries;
    using Entities.Interactions;
    using SimpleFeed.Core.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class SimpleFeedContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public SimpleFeedContext(DbContextOptions<SimpleFeedContext> options)
            : base(options)
        {
        }

        internal DbSet<ExternalLinkFeedEntryEntity> ExternalLinks { get; set; }
        internal DbSet<UploadedFileFeedEntryEntity> UploadedFiles { get; set; }
        internal DbSet<UploadedTextFeedEntryEntity> UploadedTexts { get; set; }
        internal DbSet<FeedEntryCommentEntity> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<FeedEntryCommentEntity>().Property(c => c.Id).HasColumnName("varbinary(16)");
        }
    }
}
