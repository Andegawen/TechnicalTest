using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bds.TechTest.Wpf.SearchService.Wikipedia
{
    public class WikiToSearchResultMapper
    {
        private static readonly Regex RegexOfSpanMatch = new Regex(@"<span class=""searchmatch"">([A-z,1-9]*)<\/span>");

        public static SearchResult Map(WikipediaSearchResult wiki)
        {
            var matches = RegexOfSpanMatch.Matches(wiki.Snippet);

            return new SearchResult
            {
                Source = "Wikipedia",
                Title = wiki.Title,
                Description = RegexOfSpanMatch.Replace(wiki.Snippet, "$1"),
                NavigateLink = $"{wiki.PageId}"
            };
        }
    }
}
