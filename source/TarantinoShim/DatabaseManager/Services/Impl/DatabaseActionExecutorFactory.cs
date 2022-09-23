namespace Tarantino.Core.DatabaseManager.Services.Impl
{
	using Tarantino.Core.DatabaseManager.Services.Impl;

	public class DatabaseActionExecutorFactory : IDatabaseActionExecutorFactory
	{
		private readonly IDatabaseActionResolver _resolver;
		private readonly IDatabaseCreator creator;
		private readonly IDatabaseDropper dropper;
		private readonly IDatabaseUpdater updater;

		public DatabaseActionExecutorFactory(
			IDatabaseActionResolver resolver,
			IDatabaseCreator creator,
			IDatabaseDropper dropper,
			IDatabaseUpdater updater)
		{
			_resolver = resolver;
			this.creator = creator;
			this.dropper = dropper;
			this.updater = updater;
		}

		public IEnumerable<IDatabaseActionExecutor> GetExecutors(RequestedDatabaseAction requestedDatabaseAction)
		{
			IEnumerable<DatabaseAction> actions = _resolver.GetActions(requestedDatabaseAction);

			foreach (DatabaseAction action in actions)
			{
				if (((DatabaseAction.Type)action.Value) == DatabaseAction.Type.Create)
				{
					yield return creator;
				}
				else if (((DatabaseAction.Type)action.Value) == DatabaseAction.Type.Update)
				{
                    yield return updater;
                }
                else if (((DatabaseAction.Type)action.Value) == DatabaseAction.Type.Drop)
                {
                    yield return dropper;
                }
				else
				{
					throw new ArgumentOutOfRangeException($"Action {action.DisplayName} not supported.");
				}
            }
        }
	}
}