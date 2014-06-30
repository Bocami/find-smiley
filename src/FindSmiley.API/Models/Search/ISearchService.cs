namespace FindSmiley.API.Models.Search
{
    public interface ISearchService
    {
        SearchResult Search(SearchQuery query);
    }
}