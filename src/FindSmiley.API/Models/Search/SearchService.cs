using System.Diagnostics;
using System.Linq;

namespace FindSmiley.API.Models.Search
{
    public class SearchService : ISearchService
    {
        private readonly SearchIndex searchIndex;

        public SearchService(SearchIndex searchIndex)
        {
            this.searchIndex = searchIndex;
        }

        public SearchResult Search(SearchQuery query)
        {
            if (query.Keywords == null)
                return new SearchResult()
                {
                        Documents = new SearchDocument[] {}
                };

            var keywords = query.Keywords.ToLowerInvariant().Split(' ');

            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            var searchResult = new SearchResult
            {
                 Documents = searchIndex.Entries
                    .Where(d => keywords.All(k => d.Text.Contains(k)))
                    .Select(d => d.Document)
                    .Take(5)
                    .ToArray(),
                 ElapsedMilliseconds = stopwatch.ElapsedMilliseconds
            };
            stopwatch.Stop();

            Debug.WriteLine(stopwatch.ElapsedMilliseconds);

            return searchResult;
        }
    }
}