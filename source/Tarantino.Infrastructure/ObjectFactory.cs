using StructureMap;
using Tarantino.Core;

namespace Tarantino.Infrastructure
{
  public static class ObjectFactory
  {
    public static Container Container { get; private set; }

    public static void Register()
    {
      Container = new Container(x =>
        x.Scan(s =>
        {
          s.TheCallingAssembly();
          s.AssemblyContainingType<InfrastructureDependencyRegistry>();
          s.AssemblyContainingType<CoreDependencyRegistry>();
          s.LookForRegistries();
          s.WithDefaultConventions();
        }));
    }
  }
}