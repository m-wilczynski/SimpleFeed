namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using Core.FeedEntries;
    using Entities.FeedEntries;

    internal static class UploadedTextFeedEntryMapping
    {
        public static UploadedTextFeedEntry AsDomain(this UploadedTextFeedEntryEntity entity)
        {
            var entry = new UploadedTextFeedEntry(entity.Content, entity.CreatorId.Value, entity.Id);
            entry.WithVotesAndCommentsWired(entity)
                 .WithCreationDateInjected(entity.CreationDate);
            return entry;
        }

        public static UploadedTextFeedEntryEntity AsEntity(this UploadedTextFeedEntry model)
        {
            var entity = new UploadedTextFeedEntryEntity
            {
                Id = model.Id,
                CreatorId = model.Creator.Value,
                CreationDate = model.CreationDate,
                IsPublished = model.IsPublished,
                Content = model.Content
            };
            entity.WithVotesAndCommentsWired(model);

            return entity;
        }
    }
}
