using Sieve.Models;

namespace DevicesManager.Services.Interfaces
{
    public interface IQueryFrameExecutor
    {
        Task<(IEnumerable<T> Results, int TotalResultCount)> SelectData<T>(IQueryable<T> value, SieveModel sieveModel);
    }
}
