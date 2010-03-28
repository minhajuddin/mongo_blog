using System.Collections.Generic;
using System.Linq;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;
using Norm;
using Norm.Linq;

namespace MongoBlog.Web.Infrastructure.DataAccess {
    public class PostRepository : Repository, IPostRepository {
        public PostRepository(IMongoFactory mongoFactory, ISession session)
            : base(mongoFactory) {
        }

        public IEnumerable<Post> GetAll(ISelectSpec selectSpec) {
            using (Mongo connection = Connection()) {
                var posts = new MongoQuery<Post>(new MongoQueryProvider(connection));
                return posts.Take(selectSpec.NumberOfRows).Skip(selectSpec.SkipRows).ToList();
            }
        }
    }
}