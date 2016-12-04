using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.StaticFiles;
using Unity.WebApi;
using System.Net.Http.Headers;

namespace AssettoChampionship.Web.Config
{
    public class OWINWebAPIConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseStaticFiles("/web");

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.RegisterComponents());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes
                        .Add(new MediaTypeHeaderValue("application/json"));

            appBuilder.UseWebApi(config);
        }
    }
}
