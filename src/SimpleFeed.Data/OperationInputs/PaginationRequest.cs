namespace SimpleFeed.Data.OperationInputs
{
    using System;

    public class PaginationRequest
    {
        public readonly uint Page;
        public readonly uint PageSize;

        public PaginationRequest(uint page, uint pageSize)
        {
            if (pageSize == 0 || pageSize > 50)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Invalid page size provided");
            if (page == 0)
                throw new ArgumentOutOfRangeException(nameof(page), page, "Invalid page provided");

            Page = page;
            PageSize = pageSize;
        }
    }
}
