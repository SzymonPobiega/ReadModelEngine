using ManagedViewEngine;
using ManagedViewEngine.Persistence;
using ManagedViewEngine.Persistence.Sql;
using ManagedViewEngine.Persistence.Sql.Dialects;
using NUnit.Framework;

namespace ReadModelEngine.Specs
{
    [TestFixture]
    public class SqlViewEngineSpecification : ViewEngineSpecification
    {
        protected override IViewPersistenceEngine CreatePersistenceEngine()
        {
            return new SqlViewPersistenceEngine(new MsSqlDialect(), new ConfigurationConnectionFactory());
        }
    }
}