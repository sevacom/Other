using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    public class MssqlConnectionFactory: IConnectionFactory, IQueryBuilder
    {
        private readonly string _connectionString;

        public MssqlConnectionFactory()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["MssqlDataBaseConnectionString"]
                .ConnectionString;
        }

        public IDbConnection Create()
        {
            var builder = new SqlConnectionStringBuilder(_connectionString);
            return new SqlConnection(builder.ConnectionString);
        }

        public IProductQueries ProductQueries { get; } = new MssqlProductQueries();
    }
}