using System.Collections.Generic;
using MongoBlog.Web.Domain.Entities;

namespace MongoBlog.Web.Domain.Services {
    public interface IPostRepository : IRepository {
        IEnumerable<Post> GetAll(ISelectSpec selectSpec);
    }
}