using StructureMap;

namespace Tarantino.Core
{
	public static class ObjectFactory
	{
		private static Container _container { get; set; }

		public static void Register()
		{
			_container = new Container(x => x.Scan(s =>
				{
					s.TheCallingAssembly();
					s.LookForRegistries();
				}));
		}
	}
}