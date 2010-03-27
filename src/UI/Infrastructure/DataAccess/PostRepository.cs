using System.Collections.Generic;
using System.Linq;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;
using Norm.Linq;

namespace MongoBlog.UI.Infrastructure.DataAccess {
    public class PostRepository : Repository, IPostRepository {
        public PostRepository(IMongoFactory mongoFactory)
            : base(mongoFactory) {
        }

        public IEnumerable<Post> GetAll(ISelectSpec selectSpec) {
            using (var connection = Connection()) {
                var posts = new MongoQuery<Post>(new MongoQueryProvider(connection));
                return posts.Take(selectSpec.NumberOfRows).Skip(selectSpec.SkipRows).ToList();
            }
        }
    }
}