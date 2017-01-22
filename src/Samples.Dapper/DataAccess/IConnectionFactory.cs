using System.Data;

namespace Samples.Dapper
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
