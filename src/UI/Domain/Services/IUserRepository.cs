using MongoBlog.UI.Domain.Entities;

namespace MongoBlog.UI.Domain.Services {
    public interface IUserRepository : IRepository {
        User GetByUserName(string username);
    }
}