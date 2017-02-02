namespace Samples.Dapper.DataAccess.Query
{
    public class QueryObject
    {
        public QueryObject(string sql)
        {
            Sql = sql;
        }

        public QueryObject(string sql, object @params) : this(sql)
        {
            Params = @params;
        }

        public string Sql { get; }

        public object Params { get; }
    }
}
