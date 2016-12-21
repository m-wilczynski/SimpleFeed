namespace SimpleFeed.Data.EntityFramework.EntityConfigurations.FeedEntries
{
    using Entities;
    using Entities.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class FeedEntryConfiguration
    {

        public static void WithExternalLinkConfiguration(this EntityTypeBuilder<ExternalLinkFeedEntryEntity> entityBuilder)
        {
            entityBuilder.WithFeedEntryConfig();
            entityBuilder.Property(e => e.LinkAddress).IsRequired().HasColumnName("link_uri");
            entityBuilder.ToTable("external_link_entry");
        }

        public static void WithUploadedFileConfiguration(this EntityTypeBuilder<UploadedFileFeedEntryEntity> entityBuilder)
        {
            entityBuilder.WithFeedEntryConfig();
            entityBuilder.Property(e => e.RelativeFilePath).IsRequired().HasColumnName("relative_file_path");
            entityBuilder.ToTable("uploaded_file_entry");
        }

        public static void WithUploadedTextConfiguration(this EntityTypeBuilder<UploadedTextFeedEntryEntity> entityBuilder)
        {
            entityBuilder.WithFeedEntryConfig();
            entityBuilder.Property(e => e.Content).IsRequired().HasColumnName("text_content");
            entityBuilder.ToTable("uploaded_text_entry");
        }

        private static void WithFeedEntryConfig<TFeedEntry>(this EntityTypeBuilder<TFeedEntry> entityBuilder)
            where TFeedEntry : FeedEntryEntity
        {
            entityBuilder.WithEntityConfig();
            entityBuilder.Property(e => e.IsPublished).IsRequired().HasColumnType("bit(1)").HasColumnName("is_published");
            (entityBuilder as EntityTypeBuilder<FeedEntryEntity>).HasMany(e => e.Votes).WithOne(v => v.VotedEntry).IsRequired();
            (entityBuilder as EntityTypeBuilder<FeedEntryEntity>).HasMany(e => e.Comments).WithOne(c => c.CommentedEntity).IsRequired();
        }
    }
}
