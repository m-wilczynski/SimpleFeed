namespace SimpleFeed.Data.Mappings.Interactions
{
    using Core.Interactions;
    using Entities.FeedEntries;
    using Entities.Interactions;

    internal static class FeedEntryVoteMapping
    {
        public static FeedEntryVoteEntity AsEntity(this FeedEntryVote model, FeedEntryEntity parent)
        {
            return new FeedEntryVoteEntity
            {
                Id = model.Id,
                CreationDate = model.CreationDate,
                CreatorId = model.Creator.Value,
                IsPositive = model.IsPositive,
                VotedEntry = parent
            };
        }
    }
}
