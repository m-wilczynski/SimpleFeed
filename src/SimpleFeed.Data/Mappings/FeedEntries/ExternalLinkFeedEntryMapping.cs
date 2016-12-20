namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using Core.FeedEntries;
    using Entities.FeedEntries;

    internal static class ExternalLinkFeedEntryMapping
    {
        public static ExternalLinkFeedEntry AsDomain(this ExternalLinkFeedEntryEntity entity)
        {
            var entry = new ExternalLinkFeedEntry(entity.LinkAddress, entity.CreatorId.Value, entity.Id);
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
                LinkAddress = model.LinkAddress
            };
            entity.WithVotesAndCommentsWired(model);

            return entity;
        }
    }
}
