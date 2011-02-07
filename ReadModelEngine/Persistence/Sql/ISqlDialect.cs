using System;
using System.Data;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public interface ISqlDialect
	{
		string InitializeViewMetadata { get; }

        string UniqueId { get;  }
        string CreationTime { get;  }
        string LastUpdateTime { get;  }
        string Status { get;  }
        string LastError { get;  }
        string CodeVersion { get;  }
        string GetViewMetadata { get; }

        IDbTransaction OpenTransaction(IDbConnection connection);
		IDbStatement BuildStatement(IDbConnection connection, IDbTransaction transaction, params IDisposable[] resources);
	}
}