using StructureMap;
using Tarantino.Core.DatabaseManager.Services;
using Tarantino.Core.DatabaseManager.Services.Impl;

namespace Tarantino.Infrastructure
{
  public class InfrastructureDependencyRegistry : Registry
  {
    public InfrastructureDependencyRegistry()
    {
      For<IDatabaseActionExecutor>().AddInstances(y =>
      {
        y.Type<DatabaseCreator>().Named("Create");
        y.Type<DatabaseDropper>().Named("Drop");
        y.Type<DatabaseUpdater>().Named("Update");
      });
    }
  }
}