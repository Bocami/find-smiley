using System.Threading;
using FindSmiley.API.Models.Search;
using System.Web.Http;

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
        public Search Search([FromUri]SearchQuery query)
        {
            return searchService.Search(query);
        }
    }
}
