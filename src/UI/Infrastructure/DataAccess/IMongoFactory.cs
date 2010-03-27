using Norm;

namespace MongoBlog.UI.Infrastructure.DataAccess {
    public interface IMongoFactory {
        Mongo CreateInstance();
    }

    public class MongoFactory : IMongoFactory {
        public Mongo CreateInstance() {
            return new Mongo("mongo_blog");//TODO: change to get this from config
        }
    }
}