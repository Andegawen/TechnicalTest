using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;

namespace Bds.TechTest.Wpf.SearchService
{
    public class SearchAggregatorService
    {
        private readonly IEnumerable<ISearchEngine> _engines;

        public SearchAggregatorService(IEnumerable<ISearchEngine> engines)
        {
            _engines = engines;
        }
    }
}
