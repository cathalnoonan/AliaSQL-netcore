using StructureMap;
using Tarantino.Core.Commons.Services.Security;
using Tarantino.Core.Commons.Services.Security.Impl;

namespace Tarantino.Core
{
	public class CoreDependencyRegistry : Registry
	{
		public CoreDependencyRegistry()
		{
			Scan(x =>
			     	{
			     		x.TheCallingAssembly();
						x.LookForRegistries();
			     		x.WithDefaultConventions();
			     	});

			For<IEncryptionEngine>().Use<AesEncryptionEngine>();
			For<IHashAlgorithm>().Use<SHA512HashAlgorithm>();
		}
	}
}