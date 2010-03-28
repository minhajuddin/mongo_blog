using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MongoBlog.Web.DependencyResolution;
using MongoBlog.Web.Presentation.Configuration;
using MongoBlog.Web.Infrastructure.DataAccess;

namespace MongoBlog.Web {
    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            ServiceLocator.EnsureDependenciesRegistered();
            new MongoConfigurator().Configure();
            new RouteConfigurator(RouteTable.Routes).Configure(); //configure routes
            new SparkConfigurator(ViewEngines.Engines).Configure(); //configure spark
            new ControllerFactoryConfigurator(ControllerBuilder.Current).Configure(); //configure controller factory
        }
    }
}