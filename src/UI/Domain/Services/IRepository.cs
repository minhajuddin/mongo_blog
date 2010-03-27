using System;
using System.Linq.Expressions;

namespace MongoBlog.UI.Domain.Services {
    public interface IRepository {
        void Add<T>(T entity);
        T Get<T>(Expression<Func<T, bool>> where);
    }
}