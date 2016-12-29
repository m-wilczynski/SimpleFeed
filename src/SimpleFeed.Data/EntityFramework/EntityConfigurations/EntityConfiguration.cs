namespace SimpleFeed.Data.EntityFramework.EntityMySqlConnectionStrings
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class EntityMySqlConnectionString
    {
        public static void HasBaseEntityConfig<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder)
            where TEntity : EntityBase
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Id).IsRequired().HasColumnType("binary(16)").HasColumnName("id");
            entityBuilder.Property(e => e.CreationDate).IsRequired().HasColumnName("creation_date");
            entityBuilder.Property(e => e.CreatorId).HasColumnName("creator_id");
        }
    }
}
