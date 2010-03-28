using MongoBlog.UI.Domain.Entities;
namespace MongoBlog.UI.Domain.Services {
    public interface IUserSession {
        User GetCurrentUser();
    }
}