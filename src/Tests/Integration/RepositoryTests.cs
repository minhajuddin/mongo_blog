using System.Linq.Expressions;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;
using Xunit;
using System;

namespace MongoBlog.Tests.Integration {
    public class RepositoryTests {
        [Fact]
        public void Add_adds_an_entity_to_the_db() {
            IRepository repo = new Repository();
            var post = new Post
                           {
                               Author = "Khaja Minhajuddin",
                               Title = "Mongo Blog",
                               Body = "Sample post here",
                               CreatedOn = DateTime.Now
                           };
            repo.Add(post);

            var savedPost = repo.Get<Post>(x => x.Id == post.Id);
            Assert.NotNull(savedPost);
        }

    }

    public class Repository : IRepository {
        public void Add<T>(T entity) {

        }

        public T Get<T>(Expression<Func<T, bool>> where) {
            return default(T);
        }
    }
}