using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bds.TechTest.Models
{
    public class SomeModel
    {
        private readonly SearchAggregatorService _searchAggregator;

        public SomeModel(SearchAggregatorService searchAggregator)
        {
            _searchAggregator = searchAggregator;
        }
    }
}
