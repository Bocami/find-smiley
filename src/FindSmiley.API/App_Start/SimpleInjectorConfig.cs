using FindSmiley.API.DomainModel;
using FindSmiley.API.DomainModel.LastUpdated;
using FindSmiley.API.DomainModel.Search;
using FindSmiley.API.DomainModel.Version;
using SimpleInjector;
using System;

namespace FindSmiley.API
{
    public class SimpleInjectorConfig
    {
        private static Lazy<Container> container = new Lazy<Container>(() =>
        {
            var container = new Container();
            RegisterTypes(container);
            return container;
        });

        public static Container GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(Container container)
        {
            container.Register<ILastUpdatedService>(() => new LastUpdatedService("~/App_Data/allekontrolresultater.xml"));
            container.Register<IVersionService, VersionService>();
            container.Register<IGeoDistanceCalculator, HaversineGeoDistanceCalculator>();
            container.Register<IVirksomhedRepository>(() => new XmlVirksomhedRepository("~/App_Data/allekontrolresultater.xml"));
            container.Register<SearchIndex>();
            container.Register<ISearchService, SearchService>();
        }
    }
}
