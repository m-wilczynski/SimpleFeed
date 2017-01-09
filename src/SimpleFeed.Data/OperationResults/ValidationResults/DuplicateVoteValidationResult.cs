namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    public class DuplicateVoteValidationResult : PersistenceOperationValidationResult
    {
        public DuplicateVoteValidationResult() : base(false)
        {
        }

        public override string ValidationMessage => "Attempt to add duplicate vote";
    }
}
