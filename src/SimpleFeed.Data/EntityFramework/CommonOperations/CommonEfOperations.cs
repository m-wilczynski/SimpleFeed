namespace SimpleFeed.Data.EntityFramework.CommonOperations
{
    using System;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class CommonEfOperations
    {
        public static void AddAndSave<TEntity>(this SimpleFeedContext context, TEntity entity)
            where TEntity : EntityBase
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public static void UpdateAndSave<TEntity>(this SimpleFeedContext context, TEntity entity)
            where TEntity : EntityBase
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public static void DeleteAndSave<TEntity>(this SimpleFeedContext context, TEntity entity)
            where TEntity : EntityBase
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public static void DeleteAndSave<TEntity>(this SimpleFeedContext context, Guid id)
            where TEntity : EntityBase
        {
            context.Remove(context.Find<TEntity>(id));
            context.SaveChanges();
        }

        public static void DeleteAndSave(this SimpleFeedContext context, Guid id, Type entityType)
        {
            context.Remove(context.Find(entityType, id));
            context.SaveChanges();
        }
    }
}
