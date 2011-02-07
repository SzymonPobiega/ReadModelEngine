using System;
using System.Data;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public interface IConnectionFactory
	{
		IDbConnection OpenMaster(string viewId);
		IDbConnection OpenSlave(string viewId);
	}
}