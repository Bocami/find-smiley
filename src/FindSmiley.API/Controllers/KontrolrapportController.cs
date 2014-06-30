using System.Web.Http;
using FindSmiley.API.Models.Kontrolrapport;
using System;

namespace FindSmiley.API.Controllers
{
    public class KontrolrapportController : ApiController
    {
        private readonly IKontrolrapportService kontrolrapportService;

        public KontrolrapportController()
        {
            this.kontrolrapportService = new KontrolrapportService();
        }

        public KontrolrapportDto[] Get()
        {
            return kontrolrapportService.HentAlleKontrolrapporter();
        }

        public KontrolrapportDto Get(Guid id)
        {
            return kontrolrapportService.HentKontrolrapport(id);
        } 
    }
}
