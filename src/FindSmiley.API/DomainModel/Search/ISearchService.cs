using System.Threading.Tasks;

namespace FindSmiley.API.DomainModel.Search
{
    public interface ISearchService
    {
        Task<Search> Search(SearchQuery query);
    }
}