using System.Security.Principal;
using System.Web;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;

namespace MongoBlog.Web.Presentation.Services {
    public class UserSession : IUserSession {
        private readonly IUserRepository _repository;

        public UserSession(IUserRepository repository) {
            _repository = repository;
        }

        public User GetCurrentUser() {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated) {
                string username = user.Identity.Name;
                return _repository.GetByUserName(username);
            }

            return null;
        }

    }
}