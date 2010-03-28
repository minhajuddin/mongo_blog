using System.Linq;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;
using Norm.Linq;

namespace MongoBlog.UI.Infrastructure.DataAccess {
    public class UserRepository : Repository, IUserRepository {
        public UserRepository(IMongoFactory mongoFactory)
            : base(mongoFactory) {
        }

        public User GetByUserName(string username) {
            using (var connection = Connection()) {
                var query = new MongoQuery<User>(new MongoQueryProvider(connection));
                return query.SingleOrDefault(x => x.UserName == username);
            }
        }
    }
}