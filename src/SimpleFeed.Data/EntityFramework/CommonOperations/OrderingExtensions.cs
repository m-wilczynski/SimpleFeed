namespace SimpleFeed.Data.EntityFramework.CommonOperations
{
    using System.Linq;
    using Entities;
    using OperationInputs;

    internal static class OrderingExtensions
    {
        public static IQueryable<TEntity> OrderedByDateCreated<TEntity>(this IQueryable<TEntity> query, DateCreatedOrder? order)
            where TEntity : EntityBase
        {
            if (order != null)
            {
                query = order == DateCreatedOrder.Ascending
                    ? query.OrderBy(e => e.CreationDate)
                    : query.OrderByDescending(e => e.CreationDate);
            }
            else
            {
                query = query.OrderByDescending(e => e.CreationDate);
            }

            return query;
        } 
    }
}
