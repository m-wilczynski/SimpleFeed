namespace SimpleFeed.Data.OperationResults
{
    using System;
    using OperationInputs;

    public class PaginationInfo
    {
        public readonly uint TotalPages;
        public readonly uint CurrentPage;
        public readonly uint PageSize;

        public PaginationInfo(uint totalPages, PaginationRequest paginationRequest)
        {
            TotalPages = totalPages;
            if (paginationRequest == null)
                throw new ArgumentNullException(nameof(paginationRequest));
            CurrentPage = paginationRequest.Page;
            PageSize = paginationRequest.PageSize;
        }
    }
}
