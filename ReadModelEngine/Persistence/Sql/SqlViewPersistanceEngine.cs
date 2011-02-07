using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Some code borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public class SqlViewPersistenceEngine : IViewPersistenceEngine
    {
        private readonly ISqlDialect _dialect;
        private readonly IConnectionFactory _connectionFactory;

        public SqlViewPersistenceEngine(ISqlDialect dialect, IConnectionFactory connectionFactory)
        {
            _dialect = dialect;
            _connectionFactory = connectionFactory;
        }

        public void InitializeViewMetadata(ViewMetadata viewMetadata)
        {
            ExecuteCommand(viewMetadata.UniqueId,
                           statement =>
                               {
                                   statement.AddParameter(_dialect.UniqueId, viewMetadata.UniqueId);
                                   statement.AddParameter(_dialect.CodeVersion, viewMetadata.CodeVersion);
                                   statement.AddParameter(_dialect.Status, (byte)ViewStatus.OK);
                                   statement.ExecuteWithSuppression(_dialect.InitializeViewMetadata);
                               });
        }

        public ViewMetadata GetViewMetadata(string viewId)
        {
            return ExecuteQuery(viewId,
                         query =>
                             {
                                 query.AddParameter(_dialect.UniqueId, viewId);
                                 return query.ExecuteWithQuery(_dialect.GetViewMetadata, HydrateViewMetadata).Single();
                             });
        }

        private static ViewMetadata HydrateViewMetadata(IDataRecord arg)
        {
            return new ViewMetadata
                       {
                           UniqueId = (string) arg["UniqueId"],
                           CreationTime = (DateTime) arg["CreationDate"],
                           LastUpdateTime = (DateTime?) arg["LastUpdateTime"],
                           Status = (ViewStatus)(byte) arg["Status"],
                           CodeVersion = (string)arg["CodeVersion"],
                           LastError = null //TODO
                       };
        }

        public void UpdateLastViewUpdateTime(string viewId, DateTime newLastUpdateTimeUtc)
        {
            throw new NotImplementedException();
        }

        public ViewItemData GetViewItem(string viewId, Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewItemData> GetViewItemList(string viewId, int first, int pageSize, IEnumerable<Constraint> constraints, IEnumerable<Ordering> ordering)
        {
            throw new NotImplementedException();
        }

        public void AddItem(string viewId, ViewItemData newViewItemData)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(string viewId, IEnumerable<Constraint> specification, ViewItemData newData)
        {
            throw new NotImplementedException();
        }

        public void Delete(string viewId, IEnumerable<Constraint> specification)
        {
            throw new NotImplementedException();
        }

        protected virtual T ExecuteQuery<T>(string viewId, Func<IDbStatement, T> query)
        {
            var scope = new TransactionScope(TransactionScopeOption.Suppress);
            IDbConnection connection = null;
            IDbTransaction transaction = null;
            IDbStatement statement = null;

            try
            {
                connection = _connectionFactory.OpenSlave(viewId);
                transaction = _dialect.OpenTransaction(connection);
                statement = _dialect.BuildStatement(connection, transaction, scope);
                return query(statement);
            }
            catch (Exception e)
            {
                if (statement != null)
                    statement.Dispose();
                if (transaction != null)
                    transaction.Dispose();
                if (connection != null)
                    connection.Dispose();
                scope.Dispose();

                throw new StorageException(e.Message, e);
            }
        }
        protected virtual void ExecuteCommand(string viewId, Action<IDbStatement> command)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            using (var connection = _connectionFactory.OpenMaster(viewId))
            using (var transaction = _dialect.OpenTransaction(connection))
            using (var statement = _dialect.BuildStatement(connection, transaction, scope))
            {
                try
                {
                    command(statement);
                    if (transaction != null)
                        transaction.Commit();
                }
                catch (Exception e)
                {                    
                    throw new StorageException(e.Message, e);
                }
            }
        }
    }
}