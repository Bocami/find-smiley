using System.Web.Http;
using FindSmiley.API.Models;

namespace FindSmiley.API.Controllers
{
    public class LastUpdatedController : ApiController
    {
        private readonly ILastUpdatedService lastUpdatedService;

        public LastUpdatedController(ILastUpdatedService lastUpdatedService)
        {
            this.lastUpdatedService = lastUpdatedService;
        }

        public LastUpdated Get()
        {
            return lastUpdatedService.GetLastUpdated();
        }
    }
}
