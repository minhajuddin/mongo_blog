using MongoBlog.Web.Domain.Entities;

namespace MongoBlog.Web.Domain.Services {
    public interface IUserRepository : IRepository {
        User GetByUserName(string username);
    }
}