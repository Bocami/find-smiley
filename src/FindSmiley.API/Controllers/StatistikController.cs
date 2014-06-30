using System.Web.Http;
using FindSmiley.API.Models.Statistik;

namespace FindSmiley.API.Controllers
{
    [RoutePrefix("Statistik")]
    public class StatistikController : ApiController
    {
        private readonly IStatistikService statistikService;

        public StatistikController()
        {
            this.statistikService = new StatistikService();
        }

        [HttpGet]
        [Route("Test1")]
        public dynamic Test1()
        {
            return statistikService.Test1();

        }

        [HttpGet]
        [Route("Test2")]
        public dynamic Test2()
        {
            return statistikService.Test2();

        }

        [HttpGet]
        [Route("Test3")]
        public dynamic Test3()
        {
            return statistikService.Test3();

        }
    }
}
