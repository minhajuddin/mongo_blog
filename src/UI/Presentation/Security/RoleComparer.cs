using Cosmicvent.FluentAuthentication;
using MongoBlog.UI.Domain.Entities;

namespace MongoBlog.UI.Presentation.Security {
    public class RoleComparer : IRoleComparer {
        public bool AreEqual(object firstRole, object secondRole) {
            var first = (Role)firstRole;
            var second = (Role)secondRole;
            return first == second;
        }
    }
}