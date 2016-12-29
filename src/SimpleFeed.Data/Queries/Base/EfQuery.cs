namespace SimpleFeed.Data.Queries.Base
{
    using Microsoft.Extensions.Configuration;
    using OperationResults;
    using OperationResults.ValidationResults;

    public abstract class EfQuery<TOutput>
    {
        internal SimpleFeedContext Context;
        internal readonly IConfiguration Configuration;

        protected EfQuery(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool LoadNavigationProperties { get; set; } = true;

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
}
