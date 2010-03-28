using System.Web.Mvc;
using System.Web.Routing;
using MongoBlog.Web.Domain;

namespace MongoBlog.Web.Presentation.Configuration {
    public class RouteConfigurator : IConfigurator {
        private readonly RouteCollection _routes;

        public RouteConfigurator(RouteCollection routes) {
            _routes = routes;
        }

        public void Configure() {
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            _routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Posts", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }

    }
}