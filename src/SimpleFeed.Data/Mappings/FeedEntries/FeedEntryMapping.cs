namespace SimpleFeed.Data.Mappings.FeedEntries
{
    using System;
    using Core.FeedEntries.Base;
    using Entities.FeedEntries;
    using System.Linq;
    using Interactions;

    internal static class FeedEntryMapping
    {
        public static FeedEntryBase WithVotesAndCommentsWired(this FeedEntryBase model, FeedEntryEntity entity)
        {
            if (model.Votes != null)
            {
                foreach (var vote in entity.Votes)
                {
                    var voteMade = model.MakeVote(vote.IsPositive, vote.CreatorId.Value, vote.Id);
                    voteMade.WithCreationDateInjected(vote.CreationDate);
                }
            }

            if (model.Comments != null)
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
    }
}
