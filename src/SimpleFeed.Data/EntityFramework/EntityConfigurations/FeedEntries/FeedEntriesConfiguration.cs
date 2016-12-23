namespace SimpleFeed.Data.EntityFramework.EntityConfigurations.FeedEntries
{
    using Entities.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class FeedEntriesConfiguration
    {

        public static void HasExternalLinkConfiguration(this EntityTypeBuilder<ExternalLinkFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.LinkAddress).IsRequired().HasColumnName("link_uri");
        }

        public static void HasUploadedFileConfiguration(this EntityTypeBuilder<UploadedFileFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.RelativeFilePath).IsRequired().HasColumnName("relative_file_path");
        }

        public static void HasUploadedTextConfiguration(this EntityTypeBuilder<UploadedTextFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.Content).IsRequired().HasColumnName("text_content");
        }

        public static void HasFeedEntryConfig(this EntityTypeBuilder<FeedEntryEntity> entityBuilder)
        {
            entityBuilder.HasBaseEntityConfig();
            entityBuilder.Property(e => e.IsPublished).IsRequired().HasColumnType("bit(1)").HasColumnName("is_published");
            entityBuilder.HasMany(e => e.Votes).WithOne(v => v.VotedEntry).IsRequired();
            entityBuilder.HasMany(e => e.Comments).WithOne(c => c.CommentedEntity).IsRequired();
            entityBuilder.ToTable("feed_entries");
        }
    }
}
