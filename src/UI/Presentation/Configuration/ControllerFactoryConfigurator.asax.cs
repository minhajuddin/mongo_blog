using System.Web.Mvc;
using MongoBlog.Web.Domain;

namespace MongoBlog.Web.Presentation.Configuration {
    public class ControllerFactoryConfigurator : IConfigurator {
        private readonly ControllerBuilder _controllerBuilder;

        public ControllerFactoryConfigurator(ControllerBuilder controllerBuilder) {
            _controllerBuilder = controllerBuilder;
        }

        public void Configure() {
            _controllerBuilder.SetControllerFactory(new StructureMapControllerFactory());
        }

    }
}