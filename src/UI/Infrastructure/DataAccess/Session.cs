using System;
using System.Linq;
using Norm;
using Norm.Collections;
using Norm.Linq;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class Session : ISession {

        private readonly MongoQueryProvider _provider;

        internal Session(Mongo mongo) {
            _provider = new MongoQueryProvider(mongo);
        }

        public MongoQueryProvider Provider {
            get { return _provider; }
        }

        public IQueryable<T> GetQueryable<T>() {
            return new MongoQuery<T>(_provider);
        }

        public T Get<T>(ObjectId id) {
            return GetCollection<T>().FindOne(id);
        }

        protected MongoCollection<T> GetCollection<T>() {
            return _provider.DB.GetCollection<T>();
        }

        public void Add<T>(T item) where T : class, new() {
            GetCollection<T>().Insert(item);
        }

        public void Update<T>(T item) where T : class, new() {
            GetCollection<T>().UpdateOne(item, item);
        }

        public void Drop<T>() {
            _provider.DB.DropCollection(typeof(T).Name);
        }

        public void Dispose() {
            _provider.Server.Dispose();
        }
    }

    public interface ISession : IDisposable {
        MongoQueryProvider Provider { get; }
        IQueryable<T> GetQueryable<T>();

        void Add<T>(T item) where T : class, new();
        void Update<T>(T item) where T : class, new();

        void Drop<T>();
        T Get<T>(ObjectId id);
    }
}