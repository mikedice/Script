using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace Script.TestFramework
{
    /// <summary>
    /// Owin startup class
    /// </summary>
    public class Startup
    {
        private const string testRoot = @"/tests";
        /// <summary>
        /// Configurations the specified application builder.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                    name: "test id and action",
                    routeTemplate: "api/{controller}/{id}/{action}",
                    defaults: new { id = RouteParameter.Optional }
                );

            var fileServerOpts = new FileServerOptions()
            {
                RequestPath = new PathString(testRoot),
                EnableDirectoryBrowsing = false,
            };
            appBuilder.UseFileServer(fileServerOpts);

            appBuilder.UseWebApi(config); 
        }
    }
}
