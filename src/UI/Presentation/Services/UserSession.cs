using System;
using System.Security.Principal;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;
using System.Web;

namespace MongoBlog.UI.Presentation.Services {
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