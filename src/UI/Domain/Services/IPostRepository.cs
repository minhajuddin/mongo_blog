using System.Collections.Generic;
using MongoBlog.UI.Domain.Entities;

namespace MongoBlog.UI.Domain.Services {
    public interface IPostRepository : IRepository {
        IEnumerable<Post> GetAll(ISelectSpec selectSpec);
    }
}