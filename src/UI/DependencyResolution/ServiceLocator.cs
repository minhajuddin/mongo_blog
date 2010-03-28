using System;
using MongoBlog.Web.Domain.Entities;
using StructureMap;

namespace MongoBlog.Web.DependencyResolution {
    public class ServiceLocator {
        private static readonly object _sync = new object();
        private static bool _isRegistered;

        public static void EnsureDependenciesRegistered() {
            if (_isRegistered) {
                return;
            }


            lock (_sync) {
                new ServiceLocator().RegisterDependencies();
                _isRegistered = true;
            }
        }


        public void RegisterDependencies() {
            ObjectFactory.Initialize(x => x.Scan(s =>
                                                     {
                                                         s.AssemblyContainingType<IEntity>();
                                                         s.WithDefaultConventions();
                                                         s.LookForRegistries();
                                                     }
                                              ));
        }

        public static object GetInstance(Type type) {
            return ObjectFactory.GetInstance(type);
        }

        public static T GetInstance<T>() {
            return (T)GetInstance(typeof(T));
        }
    }
}