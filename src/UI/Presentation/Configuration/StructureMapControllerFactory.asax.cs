using System;
using System.Web.Mvc;
using MongoBlog.UI.DependencyResolution;

namespace MongoBlog.UI.Presentation.Configuration {
    public class StructureMapControllerFactory : DefaultControllerFactory {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType) {
            //TODO:this should have some logging and error checking
            return (IController)ServiceLocator.GetInstance(controllerType);
        }
    }
}