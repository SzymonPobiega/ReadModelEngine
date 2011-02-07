namespace EventStore.Persistence.SqlPersistence.SqlDialects
{
	using System;
	using System.Data;

	public class FirebirdSqlDialect : CommonSqlDialect
	{
		public override string InitializeStorage
		{
			get { return FirebirdSqlStatements.InitializeStorage; }
		}
		public override string PersistCommit
		{
			get { return base.PersistCommit.Replace("/*FROM DUAL*/", "FROM rdb$database"); }
		}
		public override string AppendSnapshotToCommit
		{
			get { return base.AppendSnapshotToCommit.Replace("/*FROM DUAL*/", "FROM rdb$database"); }
		}
		public override string GetSnapshot
		{
			get { return base.GetSnapshot.Replace("SELECT *", "SELECT FIRST 1 *").Replace("LIMIT 1", string.Empty); }
		}

		public override IDbStatement BuildStatement(IDbConnection connection, IDbTransaction transaction, params IDisposable[] resources)
		{
			return new FirebirdDbStatement(connection, transaction, resources);
		}

		private class FirebirdDbStatement : DelimitedDbStatement
		{
			public FirebirdDbStatement(IDbConnection connection, IDbTransaction transaction, params IDisposable[] resources)
				: base(connection, transaction, resources)
			{
			}
		}
	}
}