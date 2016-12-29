namespace SimpleFeed.Data.Commands.Base
{
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfCommand<TOutput>
    {
        internal SimpleFeedContext Context;
        internal readonly string MySqlConnectionString;

        protected EfCommand(string mySqlConnectionString)
        {
            MySqlConnectionString = mySqlConnectionString;
        }

        public PersistenceOperationResult<TOutput> Execute()
        {
            using (Context = new SimpleFeedContext(MySqlConnectionString))
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
        internal readonly string MySqlConnectionString;

        public EfCommand(string mySqlConnectionString)
        {
            MySqlConnectionString = mySqlConnectionString;
        }

        public PersistenceOperationResult Execute()
        {
            using (Context = new SimpleFeedContext(MySqlConnectionString))
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
