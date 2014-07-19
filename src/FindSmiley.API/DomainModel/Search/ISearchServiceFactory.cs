namespace FindSmiley.API.DomainModel.Search
{
    public interface ISearchServiceFactory
    {
        ISearchService Create();
    }
}