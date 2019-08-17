using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;

namespace Bds.TechTest.Wpf.SearchService
{
    public class SearchAggregatorService
    {
        private readonly IList<ISearchEngine> _engines;

        public SearchAggregatorService(IEnumerable<ISearchEngine> engines)
        {
            _engines = engines.ToList();
        }

        public async Task<IEnumerable<SearchResult>> GetResult(string phrase)
        {
            var tasks = _engines.Select(e => e.GetSearchResults(phrase)).ToArray();
            await Task.Run(()=>Task.WaitAll(tasks));
            return tasks.SelectMany(t => t.Result);
        }
    }
}
