using System;
using StructureMap;

namespace MongoBlog.UI.DependencyResolution {
    public static class ServiceLocator {
        public static object GetInstance(Type type) {
            return ObjectFactory.GetInstance(type);
        }
    }
}