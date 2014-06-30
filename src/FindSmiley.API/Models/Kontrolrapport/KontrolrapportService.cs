using System;
using System.Linq;

namespace FindSmiley.API.Models.Kontrolrapport
{
    public class KontrolrapportDto
    {
        public int Akt { get; set; }
        public DateTime Kontroldato { get; set; }
        public int Resultat { get; set; }
        public int VirksomhedId { get; set; }
    }

    public interface IKontrolrapportService
    {
        KontrolrapportDto[] HentAlleKontrolrapporter();
        KontrolrapportDto HentKontrolrapport(Guid id);
    }

    public class KontrolrapportService : IKontrolrapportService
    {
        public KontrolrapportDto[] HentAlleKontrolrapporter()
        {
            using (var context = new FindSmileyDbContext())
            {
                return context.Kontrolrapporter.Select(kontrolrapport => new KontrolrapportDto
                {
                     Akt = kontrolrapport.Akt,
                     Kontroldato = kontrolrapport.Kontroldato,
                     Resultat= kontrolrapport.Resultat,       
                     VirksomhedId = kontrolrapport.VirksomhedId
                }).ToArray();
            }
        }

        public KontrolrapportDto HentKontrolrapport(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}