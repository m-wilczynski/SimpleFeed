namespace SimpleFeed.Data.EntityFramework.EntityConfigurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class EntityConfiguration
    {
        public static void HasBaseEntityConfig<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder)
            where TEntity : EntityBase
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Id).IsRequired().HasColumnName("id");
            entityBuilder.Property(e => e.CreationDate).IsRequired().HasColumnName("creation_date");
            entityBuilder.Property(e => e.CreatorId).HasColumnName("creator_id");
        }
    }
}
