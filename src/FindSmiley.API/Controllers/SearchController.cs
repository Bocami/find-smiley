using System.Threading;
using System.Web.Http;
using System.Threading.Tasks;
using FindSmiley.API.DomainModel.Search;

namespace FindSmiley.API.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<Search> Search([FromUri]SearchQuery query)
        {
            return await searchService.Search(query);
        }
    }
}
