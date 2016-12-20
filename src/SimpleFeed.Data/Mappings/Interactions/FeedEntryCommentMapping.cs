namespace SimpleFeed.Data.Mappings.Interactions
{
    using System.Linq;
    using Core.Interactions;
    using Entities.FeedEntries;
    using Entities.Interactions;

    internal static class FeedEntryCommentMapping
    {
        public static FeedEntryCommentEntity AsEntity(this FeedEntryComment model, FeedEntryEntity parent)
        {
            var entity = new FeedEntryCommentEntity
            {
                Id = model.Id,
                CreationDate = model.CreationDate,
                CreatorId = model.Creator.Value,
                Comment = model.Comment,
                CommentedEntity = parent
            };
            entity.Votes = model.Votes.Values.Select(v => v.AsEntity(entity)).ToList();

            return entity;
        }
    }
}
