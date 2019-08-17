using Newtonsoft.Json;

namespace Bds.TechTest.Wpf.SearchService.Wikipedia
{
    public class WikipediaResult
    {
        [JsonProperty("query")]
        public WikipediaQuery Query { get; set; }
    }

    public class WikipediaQuery
    {
        [JsonProperty("search")]
        public WikipediaSearchResult[] Results { get; set; }
    }

    public class WikipediaSearchResult
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WikipediaSearchResult) obj);
        }

        protected bool Equals(WikipediaSearchResult other)
        {
            return string.Equals(Title, other.Title) && PageId == other.PageId && WordCount == other.WordCount && string.Equals(Snippet, other.Snippet);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PageId;
                hashCode = (hashCode * 397) ^ WordCount;
                hashCode = (hashCode * 397) ^ (Snippet != null ? Snippet.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"title:{Title};pageid:{PageId};wordcount:{WordCount};snippet:{Snippet}";
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pageid")]
        public int PageId { get; set; }

        [JsonProperty("wordcount")]
        public int WordCount { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

    }
}
