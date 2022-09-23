using NHibernate;
using NHibernate.Cfg;

namespace Tarantino.Infrastructure.Commons.DataAccess.Repositories
{
	public class RepositoryBase
	{
		private ISessionFactory _sessionFactory = null;
		private Configuration _configuration = null;

		public RepositoryBase(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		public virtual string ConfigurationFile { get; set; }

		protected ISession GetSession()
		{
			if (_sessionFactory != null)
			{
				return _sessionFactory.OpenSession();
			}

			_configuration = new();
			if (ConfigurationFile != null)
			{
				_configuration.AddFile(ConfigurationFile);
			}

			_sessionFactory = _configuration.BuildSessionFactory();
			return _sessionFactory.OpenSession();
		}
	}
}