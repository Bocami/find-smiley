using System.Diagnostics;
using System.Web.Http;
using FindSmiley.API.Models.Search;

namespace FindSmiley.API.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISearchServiceFactory searchServiceFactory;

        public SearchController()
        {
            this.searchServiceFactory = new SearchServiceFactory();
        }

        [HttpGet]
        public SearchResult Search([FromUri]SearchQuery query)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var searchService = searchServiceFactory.Create();

            var searchResult = searchService.Search(query);

            stopwatch.Stop();

            Debug.WriteLine(stopwatch.ElapsedMilliseconds);

            return searchResult;
        }
    }
}
