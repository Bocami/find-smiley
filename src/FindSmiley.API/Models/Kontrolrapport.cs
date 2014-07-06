using System;

namespace FindSmiley.API.Models
{
    public class Kontrolrapport
    {
        private readonly int virksomhedId;
        private readonly int akt;
        private readonly DateTime kontroldato;
        private readonly int resultat;

        public Kontrolrapport(int virksomhedId, int akt, DateTime kontroldato, int resultat)
        {
            this.virksomhedId = virksomhedId;
            this.akt = akt;
            this.kontroldato = kontroldato;
            this.resultat = resultat;
        }

        public int VirksomhedId
        {
            get { return virksomhedId; }
        }

        public int Akt
        {
            get { return akt; }
        }

        public DateTime Kontroldato
        {
            get { return kontroldato; }
        }

        public int Resultat
        {
            get { return resultat; }
        }
    }
}
