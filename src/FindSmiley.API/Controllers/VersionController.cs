using System.Web.Http;
using FindSmiley.API.Models.Version;

namespace FindSmiley.API.Controllers
{
    [RoutePrefix("Version")]
    public class VersionController : ApiController
    {
        private readonly IVersionService versionService;

        public VersionController(IVersionService versionService)
        {
            this.versionService = versionService;
        }

        [Route("")]
        public Version Get()
        {
            return versionService.GetVersion();
        }
    }
}