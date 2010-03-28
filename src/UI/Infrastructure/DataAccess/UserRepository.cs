using System.Linq;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;
using Norm;
using Norm.Linq;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class UserRepository : Repository, IUserRepository {
        public UserRepository(IMongoFactory mongoFactory)
            : base(mongoFactory) {
        }

        public User GetByUserName(string username) {
            using (Mongo connection = Connection()) {
                var query = new MongoQuery<User>(new MongoQueryProvider(connection));
                return query.SingleOrDefault(x => x.UserName == username);
            }
        }
    }
}