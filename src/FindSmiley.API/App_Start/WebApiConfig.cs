using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Bocami.Practices.Query.WebApi;
using Bocami.Practices.WebApi;
using Newtonsoft.Json.Serialization;

namespace FindSmiley.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.RegisterCompositeHttpControllerTypeResolver(
                new QueryHttpControllerTypeResolver(),
                new DefaultHttpControllerTypeResolver()
            );

            config.RegisterCompositeHttpControllerSelector(
                new FirstGenericTypeArgumentAsControllerNameHttpControllerSelector(config),
                new DefaultHttpControllerSelector(config)
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
