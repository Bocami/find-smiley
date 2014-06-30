using System.Diagnostics;
using FindSmiley.API.Models.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindSmiley.API.Tests
{
    [TestClass]
    public class SearchServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var searchService = new SearchServiceFactory().Create();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100; i++)
            {
                searchService.Search(new SearchQuery { Keywords = "b" });
                searchService.Search(new SearchQuery { Keywords = "bu" });
                searchService.Search(new SearchQuery { Keywords = "bul" });
                searchService.Search(new SearchQuery { Keywords = "bull" });
                searchService.Search(new SearchQuery { Keywords = "bulle" });
                searchService.Search(new SearchQuery { Keywords = "buller" });
            }

            stopwatch.Stop();

            var expected = 1000;
            var actual = stopwatch.ElapsedMilliseconds;

            Debug.WriteLine(actual);

            Assert.IsTrue(actual < expected);
        }
    }
}
