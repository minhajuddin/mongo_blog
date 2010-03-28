using MongoBlog.Web.Infrastructure.DataAccess;
using MongoBlog.Web.Domain.Entities;
namespace MongoBlog.IntegrationTests.Infrastructure {
    public class DatabaseTest {
        protected SessionFactory _sessionFactory;
        protected MongoFactory _mongoFactory;

        public DatabaseTest() {
            //reset the data
            new MongoConfigurator().Configure();
            _mongoFactory = new MongoFactory();
            _sessionFactory = new SessionFactory(_mongoFactory);

            _sessionFactory.GetSession().Drop<Post>();
            _sessionFactory.GetSession().Drop<User>();
        }


    }
}