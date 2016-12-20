namespace SimpleFeed.Data.Entities
{
    using System;

    internal abstract class EntityBase
    {
        public Guid Id { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
