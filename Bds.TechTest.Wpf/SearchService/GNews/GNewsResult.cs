using Newtonsoft.Json;

namespace Bds.TechTest.Wpf.SearchService.GNews
{
    class GNewsResult
    {
        [JsonProperty("articles")]
        public GNewsEntry[] Articles { get; set; }
    }

    class GNewsEntry
    {
        [JsonProperty("source")]
        public GNewsSource Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string SourceUrl { get; set; }

        protected bool Equals(GNewsEntry other)
        {
            return Equals(Source, other.Source) && string.Equals(Author, other.Author) && string.Equals(Title, other.Title) && string.Equals(Description, other.Description) && string.Equals(SourceUrl, other.SourceUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GNewsEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Source != null ? Source.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SourceUrl != null ? SourceUrl.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Source:{Source};Author:{Author};Title:{Title};Description:{Description};SourceUrl:{SourceUrl}";
        }
    }

    class GNewsSource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        protected bool Equals(GNewsSource other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GNewsSource) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
