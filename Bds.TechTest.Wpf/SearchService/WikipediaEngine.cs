using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bds.TechTest.Wpf.SearchService.Bds.TechTest
{
    /// <remarks>https://www.mediawiki.org/wiki/API:Search#API_documentation</remarks>
    internal class WikipediaEngine : ISearchEngine
    {
        private HttpClient httpClient;

        public WikipediaEngine()
        {
            httpClient = new HttpClient();
        }
        private static Dictionary<string, string> GetParams(string phrase)
        {
            return new Dictionary<string, string>()
            {
                { "action", "query"},
                { "list", "search"},
                { "format", "json"},
                { "srsearch", phrase}
            };
        }

        public async Task<IEnumerable<SearchResult>> GetResults(string phrase)
        {
            var url = "https://en.wikipedia.org/w/api.php";
            var parameters = GetParams(phrase);
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = await httpClient.PostAsync(url, encodedContent).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return new SearchResult[0];

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var results = JsonConvert.DeserializeObject<WikipediaResult>(json);
            return results.Query.Results.Select(r => new SearchResult());
        }
    }
}