using System.Collections.Generic;
using System.Linq;

namespace FindSmiley.API.Models.Search
{
    public class SearchIndex
    {
        private readonly IEnumerable<SearchIndexEntry> entries;

        public SearchIndex(IQueryable<Virksomhed.Virksomhed> virksomheder, IQueryable<Kontrolrapport.Kontrolrapport> kontrolrapporter)
        {
            entries = (from k in kontrolrapporter
                join v in virksomheder on k.VirksomhedId equals v.Id
                group k by v into g 
                select new SearchIndexEntry
                {
                    Document = new SearchDocument
                    {
                        Navn = g.Key.Navn,
                        Adresse = g.Key.Postadresse.Vejadresse,
                        By = g.Key.Postadresse.By,
                        Postnummer = g.Key.Postadresse.Postnummer,
                        HarEliteSmiley = g.Key.HarEliteSmiley,
                        Kontrolrapporter = g
                            .Select(kontrolrapport => new SearchDocument.Kontrolrapport
                            {
                                Kontroldato = kontrolrapport.Kontroldato,
                                Resultat = kontrolrapport.Resultat,
                                Url = kontrolrapport.Url,
                            })
                            .OrderByDescending(r => r.Kontroldato)
                            .ToArray()
                    },
                    Text = string.Format("{0} {1} {2} {3}", g.Key.Navn, g.Key.Postadresse.Vejadresse, g.Key.Postadresse.Postnummer, g.Key.Postadresse.By).ToLowerInvariant()
                }).ToArray(); 

        }

        public IEnumerable<SearchIndexEntry> Entries
        {
            get
            {
                return entries;
            }
        }
    }
}