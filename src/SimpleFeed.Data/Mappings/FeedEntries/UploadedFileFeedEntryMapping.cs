namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using System;
    using Core.FeedEntries;
    using Entities.FeedEntries;

    internal static class UploadedFileFeedEntryMapping
    {
        public static UploadedFileFeedEntry AsDomain(this UploadedFileFeedEntryEntity entity)
        {
            var entry = new UploadedFileFeedEntry(new Uri(entity.RelativeFilePath), entity.CreatorId.Value, entity.Id);
            entry.WithVotesAndCommentsWired(entity)
                 .WithCreationDateInjected(entity.CreationDate);
            return entry;
        }

        public static UploadedFileFeedEntryEntity AsEntity(this UploadedFileFeedEntry model)
        {
            var entity = new UploadedFileFeedEntryEntity
            {
                Id = model.Id,
                CreatorId = model.Creator.Value,
                CreationDate = model.CreationDate,
                IsPublished = model.IsPublished,
                RelativeFilePath = model.RelativeFilePath.ToString()
            };
            entity.WithVotesAndCommentsWired(model);

            return entity;
        }
    }
}
