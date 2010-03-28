using Cosmicvent.FluentAuthentication;
using MongoBlog.Web.Domain.Entities;

namespace MongoBlog.Web.Presentation.Security {
    public class RoleComparer : IRoleComparer {
        public bool AreEqual(object firstRole, object secondRole) {
            var first = (Role)firstRole;
            var second = (Role)secondRole;
            return first == second;
        }

    }
}