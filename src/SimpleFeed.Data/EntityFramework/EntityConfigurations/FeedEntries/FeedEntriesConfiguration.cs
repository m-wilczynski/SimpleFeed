namespace SimpleFeed.Data.EntityFramework.EntityMySqlConnectionStrings.FeedEntries
{
    using Entities.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class FeedEntriesMySqlConnectionString
    {

        public static void HasExternalLinkMySqlConnectionString(this EntityTypeBuilder<ExternalLinkFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.LinkAddress).IsRequired().HasColumnName("link_uri");
        }

        public static void HasUploadedImageMySqlConnectionString(this EntityTypeBuilder<UploadedImageFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.RelativeFilePath).IsRequired().HasColumnName("relative_file_path");
        }

        public static void HasUploadedTextMySqlConnectionString(this EntityTypeBuilder<UploadedTextFeedEntryEntity> entityBuilder)
        {
            entityBuilder.Property(e => e.Content).IsRequired().HasColumnName("text_content");
        }

        public static void HasFeedEntryConfig(this EntityTypeBuilder<FeedEntryEntity> entityBuilder)
        {
            entityBuilder.HasBaseEntityConfig();
            entityBuilder.Property(e => e.IsPublished).IsRequired().HasColumnType("bit(1)").HasColumnName("is_published");
            entityBuilder.HasMany(e => e.Votes).WithOne(v => v.VotedEntry).IsRequired().OnDelete(DeleteBehavior.Cascade);
            entityBuilder.HasMany(e => e.Comments).WithOne(c => c.CommentedEntity).IsRequired().OnDelete(DeleteBehavior.Cascade);
            entityBuilder.ToTable("feed_entry");
        }
    }
}
