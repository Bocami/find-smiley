using System;
using FindSmiley.API.Models.Kontrolrapport;
using Microsoft.Practices.Unity;
using FindSmiley.API.Models.Version;

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
            container.RegisterType<IVersionService, VersionService>();

            container.RegisterType<IKontrolrapportService, KontrolrapportService>();
        }
    }
}
