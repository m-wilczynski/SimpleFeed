namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    public class PassedValidationResult : PersistenceOperationValidationResult
    {
        public PassedValidationResult() : base(true)
        {
        }

        public override string ValidationMessage => "Operation validation passed";
    }
}
