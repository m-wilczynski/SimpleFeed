namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    using System;

    public class InvalidFiletypeValidationResult : PersistenceOperationValidationResult
    {
        public readonly string FileName;

        public InvalidFiletypeValidationResult(string fileName) : base(false)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            FileName = fileName;
        }

        public override string ValidationMessage => $"Extension of {FileName} is invalid";
    }
}
