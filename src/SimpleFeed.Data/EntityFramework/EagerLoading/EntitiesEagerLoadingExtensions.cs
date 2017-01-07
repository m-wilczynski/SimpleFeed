namespace SimpleFeed.Data.EntityFramework.EagerLoading
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class EntitiesEagerLoadingExtensions
    {
        public static IQueryable<TEntity> WithCreatorIncluded<TEntity>(this IQueryable<TEntity> queryable) where TEntity : EntityBase
        {
            return queryable.Include(q => q.Creator);
        }
    }
}
