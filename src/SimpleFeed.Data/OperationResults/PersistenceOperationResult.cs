namespace SimpleFeed.Data.OperationResults
{
    using ValidationResults;

    public class PersistenceOperationResult
    {
        public readonly PersistenceOperationValidationResult ValidationResult;

        public PersistenceOperationResult(PersistenceOperationValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public virtual bool WasSuccessful => ValidationResult.WasSuccessful;
    }

    public class PersistenceOperationResult<TOperationOutput> : PersistenceOperationResult
    {
        public readonly TOperationOutput Output;

        public PersistenceOperationResult(TOperationOutput output, PersistenceOperationValidationResult validationResult)
            : base(validationResult)
        {
            Output = output;
        }

        public bool NullOutput => ReferenceEquals(Output, default(TOperationOutput));
        public override bool WasSuccessful => ValidationResult.WasSuccessful && !NullOutput;
    }
}
