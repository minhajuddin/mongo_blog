using MongoBlog.UI.Domain.Services;
using Norm;
using Norm.Linq;

namespace MongoBlog.UI.Infrastructure.DataAccess {
    public class Repository : IRepository {

        protected readonly IMongoFactory _mongoFactory;

        public Repository(IMongoFactory mongoFactory) {
            _mongoFactory = mongoFactory;
        }

        protected Mongo Connection() {
            return _mongoFactory.CreateInstance();
        }

        public void Add<T>(T entity) {
            using (var mongo = Connection()) {
                mongo.GetCollection<T>().Insert(entity);
            }

        }

        public T Get<T>(object id) {
            var provider = new MongoQueryProvider(_mongoFactory.CreateInstance());
            return provider.DB.GetCollection<T>().FindOne(new { Id = id });
        }
    }
}