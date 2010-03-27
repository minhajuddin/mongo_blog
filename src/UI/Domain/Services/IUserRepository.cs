namespace MongoBlog.UI.Domain.Services {
    public interface IRepository {
        void Add<T>(T entity);
        T Get<T>(object id);
    }
}