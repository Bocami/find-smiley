using System.Collections.Generic;
using System.Linq;

namespace FindSmiley.API.DomainModel.Search
{
    public class SearchIndex
    {
        private readonly IEnumerable<SearchDocument> documents;

        public SearchIndex(IVirksomhedRepository virksomheder)
        { 
            documents = (from v in virksomheder
                select new SearchDocument
                {
                    Virksomhed = v,
                    Text = string.Format("{0} {1} {2} {3}", v.Navn, v.Postadresse.Adresse1, v.Postadresse.Postnummer, v.Postadresse.By).ToLowerInvariant()
                }).ToArray(); 

        }

        public IEnumerable<SearchDocument> Documents
        {
            get
            {
                return documents;
            }
        }
    }
}