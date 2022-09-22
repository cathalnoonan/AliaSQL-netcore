using System.Linq;
using StructureMap;
using Tarantino.Infrastructure;

namespace Tarantino.DatabaseManager.Core
{
    public class ServiceLocator
    {
        public T CreateInstance<T>()
        {
            var instance = ObjectFactory.Container.GetInstance<T>();
            return instance;
        }

        public T CreateInstance<T>(string instanceKey)
        {
            var instance = ObjectFactory.Container.GetInstance<T>(instanceKey);
            return instance;
        }

        public T[] CreateAllInstances<T>()
        {
            var instances = ObjectFactory.Container.GetAllInstances<T>();
            return instances.ToArray();
        }
    }
}