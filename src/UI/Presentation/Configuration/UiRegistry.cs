using System;
using Cosmicvent.FluentAuthentication;
using StructureMap.Configuration.DSL;
using MongoBlog.UI.Presentation.Controllers;


namespace MongoBlog.UI.Presentation.Configuration {
    public class UiRegistry : Registry {

        public UiRegistry() {

            For<IAuthenticationSettings>()
                .Singleton()
                .Use<MongoBlogAuthenticationSettings>();

        }

    }

    public class MongoBlogAuthenticationSettings : AuthenticationSettings {
        public MongoBlogAuthenticationSettings()
            : base(new RoleComparer()) {
        }

        protected override void Configure() {
            AddRule<HomeController>();
        }
    }

    public class RoleComparer : IRoleComparer {
        public bool AreEqual(object firstRole, object secondRole) {
            throw new NotImplementedException();
        }
    }
}