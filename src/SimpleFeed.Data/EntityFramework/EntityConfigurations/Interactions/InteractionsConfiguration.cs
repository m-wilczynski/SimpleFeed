namespace SimpleFeed.Data.EntityFramework.EntityMySqlConnectionStrings.Interactions
{
    using Entities.Interactions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class InteractionsMySqlConnectionString
    {
        public static void HasFeedEntryCommentConfig(this EntityTypeBuilder<FeedEntryCommentEntity> entityBuilder)
        {
            entityBuilder.HasBaseEntityConfig();
            entityBuilder.Property(e => e.Comment).HasColumnName("comment_content").IsRequired();

            entityBuilder.HasOne(e => e.CommentedEntity).WithMany(fe => fe.Comments).IsRequired();
            entityBuilder.HasMany(e => e.Votes).WithOne(cv => cv.VotedComment).IsRequired().OnDelete(DeleteBehavior.Cascade);

            entityBuilder.ToTable("feed_entry_comment");
        }

        public static void HasCommentVoteConfig(this EntityTypeBuilder<CommentVoteEntity> entityBuilder)
        {
            entityBuilder.HasBaseEntityConfig();
            entityBuilder.Property(e => e.IsPositive).HasColumnType("bit(1)").HasColumnName("is_positive").IsRequired();

            entityBuilder.HasOne(e => e.VotedComment).WithMany(vc => vc.Votes).IsRequired();

            entityBuilder.ToTable("feed_entry_comment_vote");
        }

        public static void HasFeedEntryVoteConfig(this EntityTypeBuilder<FeedEntryVoteEntity> entityBuilder)
        {
            entityBuilder.HasBaseEntityConfig();
            entityBuilder.Property(e => e.IsPositive).HasColumnName("bit(1)").HasColumnName("is_positive").IsRequired();

            entityBuilder.HasOne(e => e.VotedEntry).WithMany(ve => ve.Votes).IsRequired();

            entityBuilder.ToTable("feed_entry_vote");
        } 
    }
}