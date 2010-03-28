using System;
using System.Web.Mvc;
using System.Web.Routing;
using MongoBlog.Web.DependencyResolution;

namespace MongoBlog.Web.Presentation.Configuration {
    public class StructureMapControllerFactory : DefaultControllerFactory {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            //TODO:this should have some logging and error checking
            return (IController)ServiceLocator.GetInstance(controllerType);
        }
    }
}