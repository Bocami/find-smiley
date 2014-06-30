using System;

namespace FindSmiley.API.Models.Kontrolrapport
{
    public class Kontrolrapport
    {
        private Kontrolrapport()
        {
        }

        public Kontrolrapport(Guid id, int akt, int virksomhedId, DateTime kontroldato, int resultat, string url)
        {
            Id = id;
            Akt = akt;
            VirksomhedId = virksomhedId;
            Kontroldato = kontroldato;
            Resultat = resultat;
            Url = url;
        }

        public Guid Id { get; private set; }
        public int VirksomhedId { get; set; }
        public int Akt { get; set; }
        public DateTime Kontroldato { get; set; }
        public int Resultat { get; set; }
        public string Url { get; set; }
    }
}
