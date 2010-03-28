using Cosmicvent.FluentAuthentication;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Presentation.Controllers;

namespace MongoBlog.Web.Presentation.Security {
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