namespace SimpleFeed.Data.Queries._Base
{
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfQuery<TOutput>
    {
        public bool LoadNavigationProperties { get; set; } = true;

        internal SimpleFeedContext Context;

        public PersistenceOperationResult<TOutput> Execute()
        {
            using (Context = new SimpleFeedContext())
            {
                var validationResult = Validate();
                if (!validationResult.WasSuccessful) return new PersistenceOperationResult<TOutput>(default(TOutput), validationResult);
                var operationResult = ExecuteInternal();
                return new PersistenceOperationResult<TOutput>(operationResult, validationResult);
            }
        }

        protected abstract TOutput ExecuteInternal();
        protected abstract PersistenceOperationValidationResult Validate();
    }
}
