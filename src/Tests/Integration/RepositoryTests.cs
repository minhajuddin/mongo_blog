using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;
using MongoBlog.UI.Infrastructure.DataAccess;
using Norm;
using Xunit;
using System;

namespace MongoBlog.Tests.Integration {
    public class RepositoryTests {
        [Fact]
        public void Add_adds_an_entity_to_the_db() {
            IRepository repo = new Repository(new MongoFactory());

            var post = new Post
                           {
                               Author = "Khaja Minhajuddin",
                               Title = "Mongo Blog",
                               Body = "Sample post here",
                               CreatedOn = DateTime.Now
                           };

            repo.Create(post);

            Console.WriteLine(post.Id);

            var savedPost = repo.Get<Post>(post.Id);

            Assert.NotNull(savedPost);
        }


        [Fact]
        public void Get_retrieves_existing_data() {
            var repo = new Repository(new MongoFactory());

            var post = repo.Get<Post>(new ObjectId("aee42504b9bc429415000000"));
            Assert.NotNull(post);
        }

    }
}