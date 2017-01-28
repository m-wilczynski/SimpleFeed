namespace SimpleFeed.Data.EntityFramework.EagerLoading
{
    using System.Linq;
    using Entities.Interactions;
    using Microsoft.EntityFrameworkCore;

    internal static class InteractionsEagerLoadingExtensions
    {
        public static IQueryable<FeedEntryCommentEntity> WithNavigationProperties(this IQueryable<FeedEntryCommentEntity> entities)
        {
            return entities.Include(e => e.CommentedEntity).Include(e => e.Votes);
        }

        public static IQueryable<FeedEntryVoteEntity> WithNavigationProperties(
            this IQueryable<FeedEntryVoteEntity> entities)
        {
            return entities.Include(e => e.VotedEntry).ThenInclude(ve => ve.Votes);
        }
    }
}
