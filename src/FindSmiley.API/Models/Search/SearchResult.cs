namespace FindSmiley.API.Models.Search
{
    public class SearchResult
    {
        public SearchDocument[] Documents { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }
}