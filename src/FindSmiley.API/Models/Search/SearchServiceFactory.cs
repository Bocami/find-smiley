using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;

namespace FindSmiley.API.Models.Search
{
    public class SearchServiceFactory : ISearchServiceFactory
    {
        private static ISearchService CreateSearchService()
        {
            Debug.WriteLine("CreateSearchService()");

            using (var context = new FindSmileyDbContext())
            {
                var virksomheder = context.Virksomheder.ToArray().AsQueryable();
                var kontrolrapporter = context.Kontrolrapporter.ToArray().AsQueryable();

                var searchIndex = new SearchIndex(virksomheder, kontrolrapporter);
                return new SearchService(searchIndex);
            }
        }

        private static void CacheEntryUpdateCallback(CacheEntryUpdateArguments arguments)
        {
            Debug.WriteLine("CacheEntryUpdateCallback()");

            arguments.UpdatedCacheItem = new CacheItem("SearchService", CreateSearchService());
            arguments.UpdatedCacheItemPolicy = CreateCachePolicy();
        }

        static CacheItemPolicy CreateCachePolicy()
        {
            Debug.WriteLine("CreateCachePolicy()");

            return new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(60),
                UpdateCallback = new CacheEntryUpdateCallback(CacheEntryUpdateCallback),
            };
        }

        static SearchServiceFactory()
        {
            Debug.WriteLine("SearchServiceFactory()");

            MemoryCache.Default.Set("SearchService", CreateSearchService(), CreateCachePolicy());
        }

        public ISearchService Create()
        {
            Debug.WriteLine("Create()");

            return (ISearchService)MemoryCache.Default.GetCacheItem("SearchService").Value;
        }
    }
}