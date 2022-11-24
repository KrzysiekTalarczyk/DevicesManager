namespace DevicesManager.Dtos.Response
{
    public class FilteredResponse<T>
    {
        public IEnumerable<T> Results { get; }
        public int TotalResultCount { get; }

        public FilteredResponse(IEnumerable<T> results, int totalResultCount)
        {
            Results = results;
            TotalResultCount = totalResultCount;
        }
    }
}
