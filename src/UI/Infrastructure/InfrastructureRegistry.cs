using StructureMap.Configuration.DSL;
using MongoBlog.Web.Infrastructure.DataAccess;
namespace MongoBlog.Web.Infrastructure {
    public class InfrastructureRegistry : Registry {
        public InfrastructureRegistry() {
            For<IMongoFactory>().Singleton();
        }
    }
}