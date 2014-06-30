using System.Web.Http;
using FindSmiley.API.Models.Virksomhed;

namespace FindSmiley.API.Controllers
{
    public class VirksomhedController : ApiController
    {
        private readonly IVirksomhedService virksomhedService;

        public VirksomhedController(IVirksomhedService virksomhedService)
        {
            this.virksomhedService = virksomhedService;
        }

        public VirksomhedDto[] Get()
        {
            return virksomhedService.HentVirksomheder();
        }

        public VirksomhedDto Get(int id)
        {
            return virksomhedService.HentVirksomhed(id);
        }
    }
}