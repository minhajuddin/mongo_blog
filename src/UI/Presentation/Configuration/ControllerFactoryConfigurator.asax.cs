using System.Web.Mvc;
using SchoolPilot.UI.Code.Configuration;

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