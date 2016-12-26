namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    public class NoPaginationProvidedValidationResult : PersistenceOperationValidationResult
    {
        public NoPaginationProvidedValidationResult() : base(false)
        {
        }

        public override string ValidationMessage => "No pagination provided for query request";
    }
}
