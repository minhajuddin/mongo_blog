using Cosmicvent.FluentAuthentication;
using MongoBlog.Web.Presentation.Security;
using StructureMap.Configuration.DSL;

namespace MongoBlog.Web.Presentation.Configuration {
    public class UiRegistry : Registry {
        public UiRegistry() {
            For<IAuthenticationSettings>()
                .Singleton()
                .Use<MongoBlogAuthenticationSettings>();
        }
    }
}