namespace FindSmiley.API.Models.Search
{
    public class Search
    {
        public SearchResult[] Results { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }
}