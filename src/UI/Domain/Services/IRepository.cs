using Norm;

namespace MongoBlog.Web.Domain.Services {
    public interface IRepository {
        void Create<T>(T entity) where T : class, new();
        T Get<T>(ObjectId id) where T : class, new();
    }
}