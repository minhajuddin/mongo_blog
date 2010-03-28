using System;
using System.Linq;
using Norm;
using Norm.Linq;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public interface ISession : IDisposable {
        MongoQueryProvider Provider { get; }
        IQueryable<T> GetQueryable<T>();

        void Add<T>(T item) where T : class, new();
        void Update<T>(T item) where T : class, new();

        void Drop<T>();
        T Get<T>(ObjectId id);
    }
}