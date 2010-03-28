using System.Collections.Generic;
using System.Linq;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class PostRepository : Repository, IPostRepository {
        public PostRepository(ISessionFactory sessionFactory)
            : base(sessionFactory) {
        }

        public IEnumerable<Post> GetAll(ISelectSpec selectSpec) {
            IEnumerable<Post> posts = null;
            WithinSession(s =>
                posts = s.GetQueryable<Post>()
                            .Take(selectSpec.NumberOfRows)
                            .Skip(selectSpec.SkipRows).ToList()
                        );
            return posts;
        }
    }
}