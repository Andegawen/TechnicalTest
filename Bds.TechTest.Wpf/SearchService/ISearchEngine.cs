using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bds.TechTest.Wpf.SearchService
{
    namespace Bds.TechTest
    {
        public interface ISearchEngine
        {
            Task<IEnumerable<SearchResult>> GetSearchResults(string phrase);
        }
    }
}
