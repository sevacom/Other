using System.Data;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }

    public interface IQueryBuilder
    {
        IProductQueries ProductQueries { get; }
    }
}
