using System.Linq;
using StructureMap;
using Tarantino.Core.Commons.Services.Configuration;

namespace Tarantino.Infrastructure.Commons.Services.Configuration
{
	public class ServiceLocator : IServiceLocator
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