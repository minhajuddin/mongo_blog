using MongoBlog.Web.Domain;
using MongoBlog.Web.Domain.Entities;
using Norm.Configuration;

namespace MongoBlog.Web.Infrastructure.DataAccess {

    public class MongoConfigurator : IConfigurator {
        public void Configure() {

            MongoConfiguration.Initialize(m =>
                                            {
                                                m.For<Post>(c => c.UseCollectionNamed("posts"));
                                                m.For<User>(c => c.UseCollectionNamed("users"));
                                            });
        }

    }

}