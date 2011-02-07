using System;
using System.Data;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public class DelegateConnectionFactory : IConnectionFactory
    {
        private readonly Func<string, IDbConnection> _openConnection;

        public DelegateConnectionFactory(Func<string, IDbConnection> openConnection)
        {
            _openConnection = openConnection;
        }

        public virtual IDbConnection OpenMaster(string viewId)
        {
            return _openConnection(viewId);
        }
        public virtual IDbConnection OpenSlave(string viewId)
        {
            return _openConnection(viewId);
        }
    }
}