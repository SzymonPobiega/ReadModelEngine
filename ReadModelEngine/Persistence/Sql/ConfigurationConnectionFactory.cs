using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public class ConfigurationConnectionFactory : IConnectionFactory
    {
        private const int DefaultShards = 16;
        private const string DefaultConnectionName = "ReadModel";
        private const string DefaultProvider = "System.Data.SqlClient";
        private readonly string _masterConnectionName;
        private readonly string _slaveConnectionName;
        private readonly int _shards;

        public ConfigurationConnectionFactory()
            : this(null, null, DefaultShards)
        {
        }
        public ConfigurationConnectionFactory(string connectionName)
            : this(connectionName, connectionName, DefaultShards)
        {
        }
        public ConfigurationConnectionFactory(string masterConnectionName, string slaveConnectionName, int shards)
        {
            _masterConnectionName = masterConnectionName ?? DefaultConnectionName;
            _slaveConnectionName = slaveConnectionName ?? _masterConnectionName;
            _shards = shards >= 0 ? shards : DefaultShards;
        }

        public virtual IDbConnection OpenMaster(string viewId)
        {
            return Open(viewId, _masterConnectionName);
        }
        public virtual IDbConnection OpenSlave(string viewId)
        {
            return Open(viewId, _slaveConnectionName);
        }
        protected virtual IDbConnection Open(string viewId, string connectionName)
        {
            var setting = ConfigurationManager.ConnectionStrings[connectionName];
            var factory = DbProviderFactories.GetFactory(setting.ProviderName ?? DefaultProvider);
            var connection = factory.CreateConnection() ?? new SqlConnection();
            connection.ConnectionString = BuildConnectionString(viewId, setting);
            connection.Open();
            return connection;
        }
        protected virtual string BuildConnectionString(string viewId, ConnectionStringSettings setting)
        {
            return _shards == 0 
                ? setting.ConnectionString 
                : string.Format(CultureInfo.InvariantCulture, setting.ConnectionString ?? string.Empty, ComputeHashKey(viewId));
        }

        protected virtual string ComputeHashKey(string viewId)
        {
            // simple sharding scheme which could easily be improved through such techniques
            // as consistent hashing (Amazon Dynamo) or other kinds of sharding.
            return (viewId.GetHashCode() % _shards).ToString();
        }
    }
}