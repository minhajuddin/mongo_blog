using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;
using MongoBlog.Web.Infrastructure.DataAccess;
using Norm;
using Xunit;
using System;

namespace MongoBlog.IntegrationTests.Infrastructure {
    public class RepositoryTests : DatabaseTest {


        [Fact]
        public void Add_adds_an_entity_to_the_db() {
            IRepository repo = new Repository(_sessionFactory);

            var post = new Post
                           {
                               Author = "Khaja Minhajuddin",
                               Title = "Mongo Blog",
                               Body = "Sample post here",
                               CreatedOn = DateTime.Now
                           };

            repo.Create(post);

            var savedPost = repo.Get<Post>(post.Id);

            Assert.NotNull(savedPost);
        }


        [Fact]
        public void Get_retrieves_existing_data() {
            var savedPost = new Post { Id = ObjectId.NewObjectId(), Title = "Test blog" };

            using (var session = _sessionFactory.GetSession()) {
                session.Add(savedPost);
            }

            var repo = new Repository(_sessionFactory);

            var post = repo.Get<Post>(savedPost.Id);
            Assert.NotNull(post);
            Assert.Equal(post.Title, savedPost.Title);
        }

    }
}