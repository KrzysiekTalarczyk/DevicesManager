using DevicesManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace DevicesManager.Services.Services
{
    public class QueryFrameExecutor : IQueryFrameExecutor
    {
        private readonly ISieveProcessor _sieveProcessor;
        public QueryFrameExecutor(ISieveProcessor sieveProcessor)
        {
            _sieveProcessor = sieveProcessor;
        }

        public async Task<(IEnumerable<T> Results, int TotalResultCount)> SelectData<T>(IQueryable<T> value, SieveModel sieveModel)
        {   
            var results = _sieveProcessor.Apply(sieveModel, value, applyPagination: false);
            var totalResultCount = results.Count(); //?
            var onePageQuery = _sieveProcessor.Apply(sieveModel, results, applyFiltering: false, applySorting: false, applyPagination: true);
            var onePageRsults = await onePageQuery.ToListAsync();
            return (onePageRsults, totalResultCount);
        }
    }
}
