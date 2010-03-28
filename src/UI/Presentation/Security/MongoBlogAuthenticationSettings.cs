using Cosmicvent.FluentAuthentication;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Presentation.Controllers;

namespace MongoBlog.UI.Presentation.Security {
    public class MongoBlogAuthenticationSettings : AuthenticationSettings {
        public MongoBlogAuthenticationSettings()
            : base(new RoleComparer()) {
        }

        protected override void Configure() {
            AddRule<PostsController>()
                   .AddAction(x => x.Create())
                   .AddRole(Role.Admin);
        }

    }
}