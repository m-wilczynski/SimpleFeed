namespace SimpleFeed.Data.OperationResults
{
    using Core;
    using Core.User;

    public class ModelWithCreator<TModel> where TModel : ModelBase
    {
        public readonly TModel Model;
        public readonly ApplicationUser Creator;

        public ModelWithCreator(TModel model, ApplicationUser creator)
        {
            Model = model;
            Creator = creator;
        }
    }
}
