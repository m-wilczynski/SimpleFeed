namespace SimpleFeed.Data.Entities
{
    using System;
    using Core.User;

    internal abstract class EntityBase
    {
        public Guid Id { get; set; }
        public Guid? CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
