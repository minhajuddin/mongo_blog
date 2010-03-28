using System;
using StructureMap;
using MongoBlog.UI.Domain.Entities;

namespace MongoBlog.UI.DependencyResolution {
    public static class ServiceLocator {
        private static object _sync = new object();



        public static void RegisterDependencies() {
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