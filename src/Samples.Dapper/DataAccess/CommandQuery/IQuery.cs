using System.Data;

namespace Samples.Dapper.DataAccess.CommandQuery
{
    public interface IQuery<out T>
    {
        T Execute(IDbConnection db);
    }
}