namespace Samples.Dapper.DataAccess.Query
{
    public class MssqlQueriesProvider : IQueriesProvider
    {
        public IProductQueries ProductQueries { get; } = new MssqlProductQueries();
    }
}