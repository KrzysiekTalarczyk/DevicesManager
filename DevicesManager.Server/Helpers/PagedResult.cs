namespace DevicesManager.Server.Helpers
{
    public struct PagedResult<T>
    {
        public List<T> Data { get; }

        public PagingInfo Paging { get; }

        public bool HasValue { get; }

        public PagedResult(IEnumerable<T> items, int? pageNumber, int? pageSize, int totalRecordCount)
        {
            pageNumber = pageNumber.HasValue ? pageNumber.Value : 1;
            pageSize = pageSize.HasValue ? pageSize.Value : totalRecordCount;

            Data = new List<T>(items);
            HasValue = items.Any();
            Paging = new PagingInfo
            {
                PageNumber = pageNumber.Value,
                PageSize = pageSize.Value,
                TotalRecordCount = totalRecordCount,
                TotalPagesCount = totalRecordCount > 0
                    ? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
                    : 0,
                HasPreviousPage = pageNumber.Value > 1,
                HasNextPage = pageNumber.Value * pageSize.Value + 1 <= totalRecordCount
            };
        }
    }
}
