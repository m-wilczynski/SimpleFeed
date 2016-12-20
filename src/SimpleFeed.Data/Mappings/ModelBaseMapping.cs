namespace SimpleFeed.Data.Mappings
{
    using System;
    using Core;

    internal static class ModelBaseMapping
    {
        public static ModelBase WithCreationDateInjected(this ModelBase model, DateTime creationDate)
        {
            //TODO: inject date through reflection
            return model;
        }

        public static ModelBase WithCreatorInjected(this ModelBase model, Guid creatorId)
        {
            //TODO: inject creator
            return model;
        }
    }
}
