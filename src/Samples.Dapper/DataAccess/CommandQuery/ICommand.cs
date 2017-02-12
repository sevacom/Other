using System.Data;

namespace Samples.Dapper.DataAccess.CommandQuery
{
    public interface ICommand
    {
        void Execute(IDbConnection db);
    }

    public interface ICommand<out T>
    {
        T Execute(IDbConnection db);
    }
}