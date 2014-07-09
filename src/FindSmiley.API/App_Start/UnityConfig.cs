using System;
using System.Web.Hosting;
using FindSmiley.API.Models;
using Microsoft.Practices.Unity;
using FindSmiley.API.Models.Version;
using FindSmiley.API.Models.Search;

namespace FindSmiley.API
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILastUpdatedService, LastUpdatedService>(new InjectionConstructor("~/App_Data/allekontrolresultater.xml"));
            container.RegisterType<IGeoDistanceCalculator, HaversineGeoDistanceCalculator>();
            container.RegisterType<IVersionService, VersionService>();
            container.RegisterType<IVirksomhedRepository, XmlVirksomhedRepository>(new ContainerControlledLifetimeManager(), new InjectionConstructor("~/App_Data/allekontrolresultater.xml"));
            container.RegisterType<SearchIndex>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISearchService, SearchService>(new ContainerControlledLifetimeManager());
        }
    }
}
