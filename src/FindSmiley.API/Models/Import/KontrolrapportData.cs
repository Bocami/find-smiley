using System;

namespace FindSmiley.API.Models.Import
{
    public class KontrolrapportData
    {
        public int VirksomhedId { get; set; }
        public int Akt { get; set; }
        public DateTime Kontroldato { get; set; }
        public int Resultat { get; set; }
        public string Url { get; set; }
    }
}