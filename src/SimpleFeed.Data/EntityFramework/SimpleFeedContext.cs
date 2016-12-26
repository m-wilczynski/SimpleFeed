namespace SimpleFeed.Data
{
    using System;
    using System.Reflection;
    using Entities.FeedEntries;
    using Entities.Interactions;
    using EntityFramework.EntityConfigurations.FeedEntries;
    using EntityFramework.EntityConfigurations.Interactions;
    using Core.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class SimpleFeedContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly IConfiguration _configuration;

        public SimpleFeedContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal DbSet<FeedEntryEntity> FeedEntries { get; set; }
        internal DbSet<ExternalLinkFeedEntryEntity> ExternalLinks { get; set; }
        internal DbSet<UploadedFileFeedEntryEntity> UploadedFiles { get; set; }
        internal DbSet<UploadedTextFeedEntryEntity> UploadedTexts { get; set; }
        internal DbSet<FeedEntryCommentEntity> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(SimpleFeedContext).GetTypeInfo().Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<FeedEntryEntity>().HasFeedEntryConfig();
            builder.Entity<ExternalLinkFeedEntryEntity>().HasExternalLinkConfiguration();
            builder.Entity<UploadedFileFeedEntryEntity>().HasUploadedFileConfiguration();
            builder.Entity<UploadedTextFeedEntryEntity>().HasUploadedTextConfiguration();
            builder.Entity<FeedEntryCommentEntity>().HasFeedEntryCommentConfig();
            builder.Entity<FeedEntryVoteEntity>().HasFeedEntryVoteConfig();
            builder.Entity<CommentVoteEntity>().HasCommentVoteConfig();
        }
    }
}
