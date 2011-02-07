using EventStore.Persistence.SqlPersistence.SqlDialects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManagedViewEngine.Persistence.Sql.Dialects
{
    public class CommonDbStatement : IDbStatement
	{
		protected IDictionary<string, object> Parameters { get; private set; }
		private readonly IDbConnection _connection;
		private readonly IDbTransaction _transaction;
		private readonly IDisposable[] _resources;

		public CommonDbStatement(IDbConnection connection, IDbTransaction transaction, params IDisposable[] resources)
		{
			this.Parameters = new Dictionary<string, object>();
			this._connection = connection;
			this._transaction = transaction;
			this._resources = resources ?? new IDisposable[0];
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (this._transaction != null)
				this._transaction.Dispose();

			if (this._connection != null)
				this._connection.Dispose();

			foreach (var resource in this._resources.Reverse().Where(resource => resource != null))
				resource.Dispose();
		}

		public virtual void AddParameter(string name, object value)
		{
			this.Parameters[name] = value;
		}

		public virtual int ExecuteWithSuppression(string commandText)
		{
			try
			{
				return this.Execute(commandText);
			}
			catch (Exception)
			{
				return 0;
			}
		}
		public virtual int Execute(string commandText)
		{
			return this.ExecuteNonQuery(commandText);
		}
        protected int ExecuteNonQuery(string commandText)
        {
            using (var command = this.BuildCommand(commandText))
                return command.ExecuteNonQuery();
        }

		public virtual IEnumerable<T> ExecuteWithQuery<T>(string queryText, Func<IDataRecord, T> select)
		{
			var command = this.BuildCommand(queryText);
			IDataReader reader = null;

			try
			{
				reader = command.ExecuteReader();
				var rows = reader.AsEnumerable(select);
				return new DisposableEnumeration<T>(rows, reader, command, this);
			}
			catch (Exception)
			{
				if (reader != null)
					reader.Dispose();

				command.Dispose();

				throw;
			}
		}

		private IDbCommand BuildCommand(string statement)
		{
			var command = this._connection.CreateCommand();
			command.Transaction = this._transaction;
			command.CommandText = statement;

			this.BuildParameters(command);

			return command;
		}
		protected virtual void BuildParameters(IDbCommand command)
		{
			foreach (var item in this.Parameters)
				this.BuildParameter(command, item.Key, item.Value);
		}
		protected virtual void BuildParameter(IDbCommand command, string name, object value)
		{
			var parameter = command.CreateParameter();
			parameter.ParameterName = name;
			this.SetParameterValue(parameter, value, null);
			command.Parameters.Add(parameter);
		}
		protected virtual void SetParameterValue(IDataParameter param, object value, DbType? type)
		{
			param.Value = value ?? DBNull.Value;
			param.DbType = type ?? (value == null ? DbType.Binary : param.DbType);
		}
	}
}