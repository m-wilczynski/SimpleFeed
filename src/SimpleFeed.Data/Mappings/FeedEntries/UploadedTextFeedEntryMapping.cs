namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using Core.FeedEntries;
    using Entities.FeedEntries;

    internal static class UploadedTextFeedEntryMapping
    {
        public static UploadedTextFeedEntry AsDomainModel(this UploadedTextFeedEntryEntity entity)
        {
            var entry = new UploadedTextFeedEntry(entity.Content, entity.Title, entity.CreatorId.Value, entity.Id)
            {
                Description = entity.Description
            };
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
                Title = model.Title,
                Description = model.Description,
                Content = model.Content
            };
            entity.WithVotesAndCommentsWired(model);

            return entity;
        }
    }
}
