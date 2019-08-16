using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bds.TechTest.Wpf.SearchService
{
    namespace Bds.TechTest
    {
        public interface ISearchEngine
        {
            Task<IEnumerable<SearchResult>> GetResults(string phrase);
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

        
    }

}
