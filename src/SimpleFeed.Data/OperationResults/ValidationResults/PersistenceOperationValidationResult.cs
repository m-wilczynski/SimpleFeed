namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    public abstract class PersistenceOperationValidationResult
    {
        public readonly bool WasSuccessful;

        protected PersistenceOperationValidationResult(bool wasSuccessful)
        {
            WasSuccessful = wasSuccessful;
        }
        
        public abstract string ValidationMessage { get; }
    }
}
