namespace SimpleFeed.Data.Commands._Base
{
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfCommand<TOutput>
    {
        internal SimpleFeedContext Context;

        public PersistenceOperationResult<TOutput> Execute()
        {
            using (Context = new SimpleFeedContext())
            {
                var validationResult = Validate();
                var operationResult = ExecuteInternal();
                return new PersistenceOperationResult<TOutput>(operationResult, validationResult);
            }
        }

        protected abstract TOutput ExecuteInternal();
        protected abstract PersistenceOperationValidationResult Validate();
    }

    public abstract class EfCommand
    {
        internal SimpleFeedContext Context;

        public PersistenceOperationResult Execute()
        {
            using (Context = new SimpleFeedContext())
            {
                var validationResult = Validate();
                ExecuteInternal();
                return new PersistenceOperationResult(validationResult);
            }
        }

        protected abstract void ExecuteInternal();
        protected abstract PersistenceOperationValidationResult Validate();
    }
}
