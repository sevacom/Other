using NUnit.Framework;
using Samples.Dapper.DataAccess;

namespace Samples.Dapper.Tests
{
    [TestFixture]
    public class ConnectionFactoryTest
    {
        [Test]
        public void ShouldMssqlCreateAndOpenConnection()
        {
            var target = new MssqlConnectionFactory();
            using (var connection = target.Create())
            {
                connection.Open();
                connection.Close();
            }
        }

        [Test]
        public void ShouldSqliteCreateAndOpenConnection()
        {
            var target = new SqliteConnectionFactory();
            using (var connection = target.Create())
            {
                connection.Open();
                connection.Close();
            }
        }
    }
}
