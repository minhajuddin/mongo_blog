namespace MongoBlog.UI.Domain.Services {
    public interface IRepository {
        void Create<T>(T entity);
        T Get<T>(object id);
    }
}