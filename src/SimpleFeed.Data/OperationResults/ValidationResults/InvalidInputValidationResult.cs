namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    public class InvalidInputValidationResult : PersistenceOperationValidationResult
    {
        public readonly string InvalidInputName;

        public InvalidInputValidationResult(string invalidInputName) : base(false)
        {
            InvalidInputName = invalidInputName;
        }

        public override string ValidationMessage => $"Invalid input provided for {InvalidInputName}";
    }
}
