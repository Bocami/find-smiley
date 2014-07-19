using FindSmiley.API;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace FindSmiley.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(GlobalConfiguration.Configuration);
        }
    }
}