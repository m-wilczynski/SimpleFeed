namespace SimpleFeed.Data.Storage.Base
{
    using System.Threading.Tasks;
    using Configuration;
    using OperationResults.ValidationResults;

    public abstract class StorageCommand
    {
        protected readonly IPersistenceConfiguration Configuration;

        protected StorageCommand(IPersistenceConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> ExecuteAsync()
        {
            if (!(Validate() is PassedValidationResult)) return null;
            return await ExecuteInternalAsync();
        }

        protected abstract Task<string> ExecuteInternalAsync();
        protected abstract PersistenceOperationValidationResult Validate();
    }
}
