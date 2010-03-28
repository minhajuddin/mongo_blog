using MongoBlog.Web.Domain.Services;
using Norm;
using Norm.Linq;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class Repository : IRepository {
        protected readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory) {
            _sessionFactory = sessionFactory;
        }

        public void Create<T>(T entity) where T : class, new() {
            using (ISession session = _sessionFactory.GetSession()) {
                session.Add(entity);
            }
        }

        public T Get<T>(ObjectId id) where T : class, new() {
            using (var session = _sessionFactory.GetSession()) {
                return session.Get<T>(id);
            }
        }

        
    }
}