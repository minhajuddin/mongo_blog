namespace MongoBlog.Web.Infrastructure.DataAccess {
    public interface ISessionFactory {
        ISession GetSession();
    }

    public class SessionFactory : ISessionFactory {
        private readonly IMongoFactory _mongoFactory;

        public SessionFactory(IMongoFactory mongoFactory) {
            _mongoFactory = mongoFactory;
        }

        public ISession GetSession() {
            return new Session(_mongoFactory.CreateInstance());
        }
    }
}