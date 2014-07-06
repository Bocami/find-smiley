namespace FindSmiley.API.Models.Search
{
    public interface ISearchService
    {
        Search Search(SearchQuery query);
    }
}