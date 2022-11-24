namespace DevicesManager.Server.Helpers
{
    public class PagingInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecordCount { get; set; }
        public int TotalPagesCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
