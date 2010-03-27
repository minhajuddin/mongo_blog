using System.Web.Mvc;

namespace MongoBlog.UI.Presentation.Configuration {
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