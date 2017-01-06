namespace SimpleFeed.Data.Mappings
{
    using System;
    using System.Reflection;
    using Core;

    internal static class ModelBaseMapping
    {
        public static ModelBase WithCreationDateInjected(this ModelBase model, DateTime creationDate)
        {
            var baseType = model.GetType();
            while (baseType != typeof(ModelBase))
            {
                baseType = baseType.GetTypeInfo().BaseType;
            }

            baseType.GetProperty(nameof(ModelBase.CreationDate)).SetValue(model, creationDate);
            return model;
        }

        public static ModelBase WithCreatorInjected(this ModelBase model, Guid creatorId)
        {
            var baseType = model.GetType();
            while (baseType != typeof(ModelBase))
            {
                baseType = baseType.GetTypeInfo().BaseType;
            }

            baseType.GetProperty(nameof(ModelBase.Creator)).SetValue(model, creatorId);
            return model;
        }
    }
}
