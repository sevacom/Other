using System.Data;
using System.Data.SQLite;

namespace Samples.Dapper.DataAccess
{
    public class SqliteConnectionFactory: IConnectionFactory
    {
        public IDbConnection Create()
        {
            IDbConnection dbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");
            return dbConnection;
        }
    }
}