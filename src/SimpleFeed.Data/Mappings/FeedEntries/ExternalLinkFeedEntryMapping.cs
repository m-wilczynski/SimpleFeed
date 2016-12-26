namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using System;
    using Core.FeedEntries;
    using Entities.FeedEntries;

    internal static class ExternalLinkFeedEntryMapping
    {
        public static ExternalLinkFeedEntry AsDomainModel(this ExternalLinkFeedEntryEntity entity)
        {
            var entry = new ExternalLinkFeedEntry(new Uri(entity.LinkAddress), entity.CreatorId.Value, entity.Id);
            entry.WithVotesAndCommentsWired(entity)
                 .WithCreationDateInjected(entity.CreationDate);
            return entry;
        }

        public static ExternalLinkFeedEntryEntity AsEntity(this ExternalLinkFeedEntry model)
        {
            var entity = new ExternalLinkFeedEntryEntity
            {
                Id = model.Id,
                CreatorId = model.Creator.Value,
                CreationDate = model.CreationDate,
                IsPublished = model.IsPublished,
                LinkAddress = model.LinkAddress.ToString()
            };
            entity.WithVotesAndCommentsWired(model);

            return entity;
        }
    }
}
