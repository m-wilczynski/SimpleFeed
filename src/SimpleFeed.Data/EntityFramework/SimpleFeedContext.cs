namespace SimpleFeed.Data
{
    using System;
    using System.Reflection;
    using Entities.FeedEntries;
    using Entities.Interactions;
    using EntityFramework.EntityMySqlConnectionStrings.FeedEntries;
    using EntityFramework.EntityMySqlConnectionStrings.Interactions;
    using Core.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class SimpleFeedContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly string _mySqlConnectionString;

        public SimpleFeedContext(string mySqlConnectionString)
        {
            _mySqlConnectionString = mySqlConnectionString;
        }

        internal DbSet<FeedEntryEntity> FeedEntries { get; set; }
        internal DbSet<ExternalLinkFeedEntryEntity> ExternalLinks { get; set; }
        internal DbSet<UploadedImageFeedEntryEntity> UploadedImages { get; set; }
        internal DbSet<UploadedTextFeedEntryEntity> UploadedTexts { get; set; }
        internal DbSet<FeedEntryCommentEntity> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_mySqlConnectionString,
                b => b.MigrationsAssembly(typeof(SimpleFeedContext).GetTypeInfo().Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<FeedEntryEntity>().HasFeedEntryConfig();
            builder.Entity<ExternalLinkFeedEntryEntity>().HasExternalLinkMySqlConnectionString();
            builder.Entity<UploadedImageFeedEntryEntity>().HasUploadedImageMySqlConnectionString();
            builder.Entity<UploadedTextFeedEntryEntity>().HasUploadedTextMySqlConnectionString();
            builder.Entity<FeedEntryCommentEntity>().HasFeedEntryCommentConfig();
            builder.Entity<FeedEntryVoteEntity>().HasFeedEntryVoteConfig();
            builder.Entity<CommentVoteEntity>().HasCommentVoteConfig();
        }
    }
}
