using System.Data;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    public interface IConnectionFactory
    {
        IDbConnection Create();

        IQueriesProvider QueriesProvider { get; }
    }
}
