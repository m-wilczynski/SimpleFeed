namespace SimpleFeed.Data.EntityFramework.EntityConfigurations.FeedEntries
{
    using Entities.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class FeedEntriesConfiguration
    {

        public static void HasExternalLinkConfiguration(this EntityTypeBuilder<ExternalLinkFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.LinkAddress).IsRequired().HasColumnName("link_uri");
        }

        public static void HasUploadedImageConfiguration(this EntityTypeBuilder<UploadedImageFeedEntryEntity> entityBuilder)
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
            entityBuilder.Property(e => e.Title).HasColumnName("title");
            entityBuilder.Property(e => e.Description).HasColumnName("description");
            entityBuilder.HasMany(e => e.Votes).WithOne(v => v.VotedEntry).IsRequired().OnDelete(DeleteBehavior.Cascade);
            entityBuilder.HasMany(e => e.Comments).WithOne(c => c.CommentedEntity).IsRequired().OnDelete(DeleteBehavior.Cascade);
            entityBuilder.ToTable("feed_entry");
        }
    }
}
