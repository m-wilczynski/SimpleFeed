namespace SimpleFeed.Data.Commands.Interactions
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using Entities.FeedEntries;
    using Entities.Interactions;
    using EntityFramework.CommonOperations;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Mappings.Interactions;
    using Microsoft.EntityFrameworkCore;
    using OperationResults.ValidationResults;

    public class AddOrSwapVoteForFeedEntry : EfCommand<FeedEntryBase>
    {
        public AddOrSwapVoteForFeedEntry(IPersistenceConfiguration configuration) 
            : base(configuration)
        {
        }

        public Guid VotedEntryId { get; set; }
        public bool IsPositive { get; set; }
        public Guid VoterId { get; set; }

        protected override FeedEntryBase ExecuteInternal()
        {
            var entry = Context.FeedEntries.AsNoTracking().WithNavigationProperties()
                .SingleOrDefault(e => e.Id.Equals(VotedEntryId)).AsDomainModelResolved();

            var userVote = entry.Votes.Values
                .SingleOrDefault(v => v.Creator.Equals(VoterId));

            if (userVote != null && userVote.IsPositive == IsPositive) return null;
            if (userVote != null) entry.RemoveVote(userVote.Id);

            var newVote = entry.MakeVote(IsPositive, VoterId);
            if (newVote == null) return null;

            var entryEntity = entry.AsEntityResolved();
            var attachedEntity = Context.Set<FeedEntryEntity>().Attach(entryEntity).Entity;
            Context.Entry(entryEntity).State = EntityState.Modified;
            Context.Entry(attachedEntity.Votes.SingleOrDefault(v => v.Id == newVote.Id)).State = EntityState.Added;
            if (userVote != null)
                Context.Entry(userVote.AsEntity(attachedEntity)).State = EntityState.Deleted;
            Context.SaveChanges();

            return entry;
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (VotedEntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(VotedEntryId));
            if (VoterId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(VoterId));
            if (Context.FeedEntries.AsNoTracking().SingleOrDefault(fe => fe.Id.Equals(VotedEntryId)) == null)
                return new NotFoundValidationResult<FeedEntryBase>(VotedEntryId);
            return new PassedValidationResult();
        }
    }
}
