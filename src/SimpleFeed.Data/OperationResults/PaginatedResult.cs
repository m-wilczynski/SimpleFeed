namespace SimpleFeed.Data.OperationResults
{
    using System;
    using System.Collections.Generic;

    public class PaginatedResult<T>
    {
        public ICollection<T> Result { get; }
        public PaginationInfo PaginationInfo { get; }

        public PaginatedResult(ICollection<T> result, PaginationInfo paginationInfo)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            if (paginationInfo == null)
                throw new ArgumentNullException(nameof(paginationInfo));

            Result = result;
            PaginationInfo = paginationInfo;
        }
    }
}
