using Cosmicvent.FluentAuthentication;
using MongoBlog.UI.Presentation.Security;
using StructureMap.Configuration.DSL;


namespace MongoBlog.UI.Presentation.Configuration {
    public class UiRegistry : Registry {

        public UiRegistry() {

            For<IAuthenticationSettings>()
                .Singleton()
                .Use<MongoBlogAuthenticationSettings>();

        }

    }
}