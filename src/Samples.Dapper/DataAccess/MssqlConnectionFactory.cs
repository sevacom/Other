using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    public class MssqlConnectionFactory: IConnectionFactory
    {
        private readonly string _connectionString;

        public MssqlConnectionFactory()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["MssqlDataBaseConnectionString"]
                .ConnectionString;
        }

        public IQueriesProvider QueriesProvider { get; } = new MssqlQueriesProvider();

        public IDbConnection Create()
        {
            var builder = new SqlConnectionStringBuilder(_connectionString);
            return new SqlConnection(builder.ConnectionString);
        }
    }
}