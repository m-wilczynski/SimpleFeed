namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using System;
    using Core.FeedEntries;
    using Entities.FeedEntries;

    internal static class UploadedImageFeedEntryMapping
    {
        public static UploadedImageFeedEntry AsDomainModel(this UploadedImageFeedEntryEntity entity)
        {
            var entry = new UploadedImageFeedEntry(entity.RelativeFilePath, entity.Title, entity.CreatorId.Value, entity.Id);
            entry.WithVotesAndCommentsWired(entity)
                 .WithCreationDateInjected(entity.CreationDate);
            return entry;
        }

        public static UploadedImageFeedEntryEntity AsEntity(this UploadedImageFeedEntry model)
        {
            var entity = new UploadedImageFeedEntryEntity
            {
                Id = model.Id,
                CreatorId = model.Creator.Value,
                CreationDate = model.CreationDate,
                IsPublished = model.IsPublished,
                Title = model.Title,
                Description = model.Description,
                RelativeFilePath = model.RelativeFilePath.ToString()
            };
            entity.WithVotesAndCommentsWired(model);

            return entity;
        }
    }
}
