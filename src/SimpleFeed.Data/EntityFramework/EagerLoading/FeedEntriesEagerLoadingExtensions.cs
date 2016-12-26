namespace SimpleFeed.Data.EntityFramework.EagerLoading
{
    using System.Linq;
    using Entities.FeedEntries;
    using Microsoft.EntityFrameworkCore;

    internal static class FeedEntriesEagerLoadingExtensions
    {
        public static IQueryable<FeedEntryEntity> WithNavigationProperties(this IQueryable<FeedEntryEntity> entities)
        {
            return entities.Include(i => i.Comments).Include(i => i.Votes);
        }
    }
}
