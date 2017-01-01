namespace SimpleFeed.Data.Commands.Base
{
    using Configuration;
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfCommand<TOutput>
    {
        protected readonly IPersistenceConfiguration Configuration;
        internal SimpleFeedContext Context;

        protected EfCommand(IPersistenceConfiguration configuration)
        {
            Configuration = configuration;           
        }

        public PersistenceOperationResult<TOutput> Execute()
        {
            using (Context = new SimpleFeedContext(Configuration))
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

    public abstract class EfCommand
    {
        internal SimpleFeedContext Context;
        protected readonly IPersistenceConfiguration Configuration;

        protected EfCommand(IPersistenceConfiguration configuration)
        {
            Configuration = configuration;
        }

        public PersistenceOperationResult Execute()
        {
            using (Context = new SimpleFeedContext(Configuration))
            {
                var validationResult = Validate();
                if (!validationResult.WasSuccessful) return new PersistenceOperationResult(validationResult);
                ExecuteInternal();
                return new PersistenceOperationResult(validationResult);
            }
        }

        protected abstract void ExecuteInternal();
        protected abstract PersistenceOperationValidationResult Validate();
    }
}
