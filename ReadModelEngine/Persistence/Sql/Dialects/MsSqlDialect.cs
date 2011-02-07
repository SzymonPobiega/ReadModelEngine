namespace ManagedViewEngine.Persistence.Sql.Dialects
{
	public class MsSqlDialect : CommonSqlDialect
	{
	    public override string InitializeViewMetadata
	    {
	        get { return MsSqlStatements.InitializeViewMetadata; }
	    }

	    public override string GetViewMetadata
	    {
            get { return MsSqlStatements.GetViewMetadata; }
	    }
	}
}