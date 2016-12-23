namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    public class InvalidInputValidationResult : PersistenceOperationValidationResult
    {
        public readonly string InvalidInputName;

        public InvalidInputValidationResult(bool wasSuccessful, string invalidInputName) : base(wasSuccessful)
        {
            InvalidInputName = invalidInputName;
        }

        public override string ValidationMessage => $"Invalid input provided for {InvalidInputName}";
    }
}
