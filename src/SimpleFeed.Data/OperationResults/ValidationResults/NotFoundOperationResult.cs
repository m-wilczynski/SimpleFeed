namespace SimpleFeed.Data.OperationResults.ValidationResults
{
    using System;
    using Core;

    public class NotFoundValidationResult<TModel> : PersistenceOperationValidationResult
    {
        public readonly Guid NotFoundId;
        public readonly Type NotFoundType;

        public NotFoundValidationResult(Guid notFoundId) : base(false)
        {
            if (notFoundId.Equals(Guid.Empty))
                throw new InvalidOperationException(nameof(notFoundId));
            NotFoundId = notFoundId;
            NotFoundType = typeof(TModel);
        }

        public override string ValidationMessage 
            => $"{NotFoundType.Name} model of id {NotFoundId} not found";
    }
}
