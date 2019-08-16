using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bds.TechTest
{
    public interface ISearchEngine
    {
        Task<IEnumerable<SearchResult>> GetResults(string phrase);
    }

    public class SearchResult
    {
    }

    class GoogleEngine : ISearchEngine
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<IEnumerable<SearchResult>> GetResults(string phrase)
        {
            var response = await client.GetAsync("https://www.google.com/search?q=asp+net+core+timer+typescript");
            if (response.IsSuccessStatusCode)
            {
                return new SearchResult[0];
            }
            return new SearchResult[0];
        }
    }

    public class SearchAggregatorService
    {
        private readonly IEnumerable<ISearchEngine> _engines;

        public SearchAggregatorService(IEnumerable<ISearchEngine> engines)
        {
            _engines = engines;
        }
    }
}
