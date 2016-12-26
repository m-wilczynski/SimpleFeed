namespace SimpleFeed.Data.Commands._Base
{
    using Microsoft.Extensions.Configuration;
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfCommand<TOutput>
    {
        internal SimpleFeedContext Context;
        internal readonly IConfiguration Configuration;

        public EfCommand(IConfiguration configuration)
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
        internal readonly IConfiguration Configuration;

        public EfCommand(IConfiguration configuration)
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
