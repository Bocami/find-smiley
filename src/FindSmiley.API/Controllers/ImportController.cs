using System.Web.Http;
using FindSmiley.API.Models;
using FindSmiley.API.Models.Import;

namespace FindSmiley.API.Controllers
{
    [RoutePrefix("Import")]
    public class ImportController : ApiController
    {
        [Route("All")]
        [HttpGet]
        public void All()
        {
            using (var context = new FindSmileyDbContext())
            {
                var importService = new ImportService(context);

                importService.ImportAll();
            }
        }

        [Route("Today")]
        [HttpGet]
        public void Today()
        {
            using (var context = new FindSmileyDbContext())
            {
                var importService = new ImportService(context);

                importService.ImportToday();
            }
        }

        [Route("Yesterday")]
        [HttpGet]
        public void Yesterday()
        {
            using (var context = new FindSmileyDbContext())
            {
                var importService = new ImportService(context);

                importService.ImportYesterday();
            }
        }
    }
}
