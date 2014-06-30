using System;
using System.Collections.Generic;

namespace FindSmiley.API.Models.Search
{
    public class SearchDocument
    {
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
        public string By { get; set; }
        public bool HarEliteSmiley { get; set; }
        public IEnumerable<Kontrolrapport> Kontrolrapporter { get; set; }

        public class Kontrolrapport
        {
            public DateTime Kontroldato { get; set; }
            public int Resultat { get; set; }
            public string Url { get; set; }
        }
    }
}