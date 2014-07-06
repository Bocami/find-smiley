using System.Data.Entity;
using System.Web.Http;
using FindSmiley.API;
using FindSmiley.API.Models;
using Microsoft.Owin;
using Owin;

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