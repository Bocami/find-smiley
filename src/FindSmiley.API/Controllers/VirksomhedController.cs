using System.Linq;
using System.Web.Http;
using FindSmiley.API.DomainModel;

namespace FindSmiley.API.Controllers
{
    public class VirksomhedController : ApiController
    {
        private readonly IVirksomhedRepository virksomhedRepository;

        public VirksomhedController(IVirksomhedRepository virksomhedRepository)
        {
            this.virksomhedRepository = virksomhedRepository;
        }

        public Virksomhed[] Get()
        {
            return virksomhedRepository.ToArray();
        }
    }
}
