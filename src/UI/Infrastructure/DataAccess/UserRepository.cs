using System.Linq;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class UserRepository : Repository, IUserRepository {
        public UserRepository(ISessionFactory sessionFactory)
            : base(sessionFactory) {
        }

        public User GetByUserName(string username) {
            User user = null;
            WithinSession(s => user = s.GetQueryable<User>().SingleOrDefault(x => x.UserName == username));
            return user;
        }
    }
}