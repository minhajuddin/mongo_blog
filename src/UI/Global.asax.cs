using System.Web.Mvc;
using System.Web.Routing;
using MongoBlog.UI.Presentation.Configuration;

namespace MongoBlog.UI {
    public class MvcApplication : System.Web.HttpApplication {

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            new RouteConfigurator(RouteTable.Routes).Configure();//configure routes
            new SparkConfigurator(ViewEngines.Engines).Configure();//configure spark
            new ControllerFactoryConfigurator(ControllerBuilder.Current).Configure();//configure controller factory

        }
    }
}