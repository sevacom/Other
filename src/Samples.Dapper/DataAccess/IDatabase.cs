using System;
using System.Collections.Generic;
using Samples.Dapper.DataAccess.CommandQuery;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    public interface IDatabase
    {
        T Execute<T>(IQuery<T> query);

        void Execute(ICommand command);

        T Execute<T>(ICommand<T> command);

        IEnumerable<T> Execute<T>(QueryObject query);

        int Execute(QueryObject query);
    }

    public class Database : IDatabase
    {
        private readonly IConnectionFactory _connectionFactory;

        public Database(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            _connectionFactory = connectionFactory;
        }

        public T Execute<T>(IQuery<T> query)
        {
            using (var connection = _connectionFactory.Create())
                return query.Execute(connection);
        }

        public void Execute(ICommand command)
        {
            using (var connection = _connectionFactory.Create())
                command.Execute(connection);
        }

        public T Execute<T>(ICommand<T> command)
        {
            using (var connection = _connectionFactory.Create())
                return command.Execute(connection);
        }

        public IEnumerable<T> Execute<T>(QueryObject query)
        {
            using (var connection = _connectionFactory.Create())
                return connection.Query<T>(query);
        }

        public int Execute(QueryObject query)
        {
            using (var connection = _connectionFactory.Create())
                return connection.Execute(query);
        }
    }
}