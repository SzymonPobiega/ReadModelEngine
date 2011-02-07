using System;
using System.Data;

namespace ManagedViewEngine.Persistence.Sql.Dialects
{
    public abstract class CommonSqlDialect : ISqlDialect
    {
        public abstract string InitializeViewMetadata { get; }
        public abstract string GetViewMetadata { get; }

        public string UniqueId
        {
            get { return "@UniqueId"; }
        }

        public string CreationTime
        {
            get { return "@CreationTime"; }
        }

        public string LastUpdateTime
        {
            get { return "@LastUpdateTime"; }
        }

        public string Status
        {
            get { return "@Status"; }
        }

        public string LastError
        {
            get { return "@LastError"; }
        }

        public string CodeVersion
        {
            get { return "@CodeVersion"; }
        }


        public virtual IDbTransaction OpenTransaction(IDbConnection connection)
		{
			return null;
		}
		public virtual IDbStatement BuildStatement(IDbConnection connection, IDbTransaction transaction, params IDisposable[] resources)
		{
			return new CommonDbStatement(connection, transaction, resources);
		}
	}
}