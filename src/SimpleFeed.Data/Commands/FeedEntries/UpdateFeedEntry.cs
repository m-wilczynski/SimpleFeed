namespace SimpleFeed.Data.Commands.FeedEntries
{
    using System;
    using System.Linq;
    using Base;
    using Configuration;
    using Core.FeedEntries.Base;
    using EntityFramework.EagerLoading;
    using Mappings.FeedEntries;
    using Microsoft.EntityFrameworkCore;
    using OperationResults.ValidationResults;

    public class UpdateFeedEntry : EfCommand
    {
        public UpdateFeedEntry(IPersistenceConfiguration configuration) : base(configuration)
        {
        }

        public Guid UpdatedEntryId { get; set; }
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }

        protected override void ExecuteInternal()
        {
            var entry = Context.FeedEntries.AsNoTracking().WithNavigationProperties().WithCreatorIncluded()
                .SingleOrDefault(fe => fe.Id.Equals(UpdatedEntryId)).AsDomainModelResolved();

            if (!string.IsNullOrEmpty(NewTitle)) entry.Title = NewTitle;
            if (!string.IsNullOrEmpty(NewDescription)) entry.Description = NewDescription;

            var attached = Context.FeedEntries.Attach(entry.AsEntityResolved());
            Context.Entry(attached.Entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        protected override PersistenceOperationValidationResult Validate()
        {
            if (UpdatedEntryId.Equals(Guid.Empty))
                return new InvalidInputValidationResult(nameof(UpdatedEntryId));
            if (Context.FeedEntries.AsNoTracking().SingleOrDefault(fe => fe.Id.Equals(UpdatedEntryId)) == null)
                return new NotFoundValidationResult<FeedEntryBase>(UpdatedEntryId);
            return new PassedValidationResult();
        }
    }
}
