using System.Linq;
using System.Reflection;
using System.Web.Http;
using Bocami.Practices.Query.SimpleInjector;
using FindSmiley.API;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorWebApiActivator), "Start")]

namespace FindSmiley.API
{
    /// <summary>Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET</summary>
    public static class SimpleInjectorWebApiActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            var container = SimpleInjectorConfig.GetConfiguredContainer();
            
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            var assemblies = GetAssemblies();

            container.RegisterQueryHandlers(assemblies);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        public static Assembly[] GetAssemblies()
        {
            return GlobalConfiguration.Configuration.Services.GetAssembliesResolver().GetAssemblies().ToArray();
        }
    }
}
