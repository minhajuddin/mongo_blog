using MongoBlog.Web.Domain.Entities;

namespace MongoBlog.Web.Domain.Services {
    public interface IUserSession {
        User GetCurrentUser();
    }
}