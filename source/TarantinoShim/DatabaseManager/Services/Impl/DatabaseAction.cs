using Tarantino.Core.Commons.Model.Enumerations;

namespace Tarantino.Core.DatabaseManager.Services.Impl
{
	namespace Tarantino.Core.DatabaseManager.Services.Impl
	{
		public class DatabaseAction : Enumeration
		{
			public enum Type : int
			{
				Create,
				Update,
				Drop,
			}

			public static readonly DatabaseAction Create = new(Type.Create, "Create");
			public static readonly DatabaseAction Update = new(Type.Update, "Update");
			public static readonly DatabaseAction Drop = new(Type.Drop, "Drop");

			public DatabaseAction()
			{
			}

			public DatabaseAction(Type value, string displayName) : base((int)value, displayName)
			{
			}
		}
	}	
}