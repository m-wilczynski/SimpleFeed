namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using System;
    using Core.FeedEntries.Base;
    using Entities.FeedEntries;
    using System.Linq;
    using Core.FeedEntries;
    using Interactions;
    using OperationResults;

    internal static class FeedEntryMapping
    {
        public static FeedEntryBase WithVotesAndCommentsWired(this FeedEntryBase model, FeedEntryEntity entity)
        {
            if (entity.Votes != null)
            {
                foreach (var vote in entity.Votes)
                {
                    var voteMade = model.MakeVote(vote.IsPositive, vote.CreatorId.Value, vote.Id);
                    voteMade.WithCreationDateInjected(vote.CreationDate);
                }
            }

            if (entity.Comments != null)
            {
                foreach (var comment in entity.Comments)
                {
                    var commentMade = model.MakeComment(comment.Comment, comment.Id);
                    if (commentMade == null) continue;

                    commentMade.WithCreationDateInjected(comment.CreationDate);
                    if (comment.CreatorId.HasValue) commentMade.WithCreatorInjected(comment.CreatorId.Value);

                    if (comment.Votes == null) continue;
                    
                    foreach (var vote in comment.Votes)
                    {
                        var voteMade = commentMade.MakeVote(vote.IsPositive, vote.CreatorId.Value, vote.Id);
                        voteMade.WithCreationDateInjected(vote.CreationDate);
                    }
                }
            }

            return model;
        }

        public static FeedEntryEntity WithVotesAndCommentsWired(this FeedEntryEntity entity, FeedEntryBase model)
        {
            entity.Votes = model.Votes.Values.Select(v => v.AsEntity(entity)).ToList();
            entity.Comments = model.Comments.Values.Select(c => c.AsEntity(entity)).ToList();
            return entity;
        }

        public static FeedEntryBase AsDomainModelResolved(this FeedEntryEntity entity)
        {
            if (entity is ExternalLinkFeedEntryEntity)
                return ((ExternalLinkFeedEntryEntity) entity).AsDomainModel();
            if (entity is UploadedImageFeedEntryEntity)
                return ((UploadedImageFeedEntryEntity) entity).AsDomainModel();
            if (entity is UploadedTextFeedEntryEntity)
                return ((UploadedTextFeedEntryEntity) entity).AsDomainModel();
            throw new InvalidOperationException($"Mapping for {entity.GetType()} is not defined");
        }

        public static ModelWithCreator<FeedEntryBase> AsDomainModelResolvedWithCreator(this FeedEntryEntity entity)
        {
            return new ModelWithCreator<FeedEntryBase>(entity.AsDomainModelResolved(), entity.Creator);
        }

        public static FeedEntryEntity AsEntityResolved(this FeedEntryBase model)
        {
            if (model is ExternalLinkFeedEntry)
                return ((ExternalLinkFeedEntry) model).AsEntity();
            if (model is UploadedImageFeedEntry)
                return ((UploadedImageFeedEntry) model).AsEntity();
            if (model is UploadedTextFeedEntry)
                return ((UploadedTextFeedEntry) model).AsEntity();
            throw new InvalidOperationException($"Mapping for {model.GetType()} is not defined");
        }
    }
}
