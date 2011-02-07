using System;
using System.Collections.Generic;
using System.Data;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public interface IDbStatement : IDisposable
	{
		void AddParameter(string name, object value);

		int Execute(string commandText);
		int ExecuteWithSuppression(string commandText);

		IEnumerable<T> ExecuteWithQuery<T>(string queryText, Func<IDataRecord, T> select);
	}
}