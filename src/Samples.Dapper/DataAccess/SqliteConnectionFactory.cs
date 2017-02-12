using System.Data;
using System.Data.SQLite;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    public class SqliteConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create()
        {
            IDbConnection dbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");
            return dbConnection;
        }

        public IProductQueries ProductQueries { get; }
    }
}