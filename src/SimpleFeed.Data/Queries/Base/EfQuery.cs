namespace SimpleFeed.Data.Queries.Base
{
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfQuery<TOutput>
    {
        internal SimpleFeedContext Context;
        internal readonly string MySqlConnectionString;

        protected EfQuery(string mySqlConnectionString)
        {
            MySqlConnectionString = mySqlConnectionString;
        }

        public bool LoadNavigationProperties { get; set; } = true;

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
}
