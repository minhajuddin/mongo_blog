using System;
using MongoBlog.Web.Domain.Services;
using Norm;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class Repository : IRepository {
        protected readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory) {
            _sessionFactory = sessionFactory;
        }

        public void Create<T>(T entity) where T : class, new() {
            WithinSession(session => session.Add(entity));
        }

        public T Get<T>(ObjectId id) where T : class, new() {
            T entity = null;
            WithinSession(s => entity = s.Get<T>(id));
            return entity;
        }

        public void WithinSession(Action<ISession> action) {
            using (var session = _sessionFactory.GetSession()) {
                action(session);
            }
        }
    }
}