using System.Diagnostics;
using System.Linq;

namespace FindSmiley.API.Models.Search
{
    public class SearchService : ISearchService
    {
        private readonly SearchIndex searchIndex;
        private readonly IGeoDistanceCalculator geoDistanceCalculator;

        public SearchService(SearchIndex searchIndex, IGeoDistanceCalculator geoDistanceCalculator)
        {
            this.searchIndex = searchIndex;
            this.geoDistanceCalculator = geoDistanceCalculator;
        }

        public Search Search(SearchQuery query)
        {
            if (query.Keywords == null)
                return new Search()
                {
                    Results = new SearchResult[] {}
                };

            var keywords = query.Keywords.ToLowerInvariant().Split(' ');

            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            var geo = new Geo(query.Latitude, query.Longitude);

            var results = searchIndex.Documents
            .Where(document => keywords.All(keyword => document.Text.Contains(keyword)))
            .Select(document => new
            {
                Document = document, 
                Distance = geoDistanceCalculator.Calculate(geo, document.Virksomhed.Geo)
            })
            .OrderBy(document => document.Distance)
            .Skip(query.Offset)
            .Take(10)
            .Select(o => new SearchResult
            {
                Virksomhed = o.Document.Virksomhed,
                Distance = o.Distance
            })
            .ToArray();
               
            stopwatch.Stop();

            return new Search
            {
                Results = results,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds
            };
        }
    }
}