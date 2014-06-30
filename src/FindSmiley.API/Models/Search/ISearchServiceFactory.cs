namespace FindSmiley.API.Models.Search
{
    public interface ISearchServiceFactory
    {
        ISearchService Create();
    }
}