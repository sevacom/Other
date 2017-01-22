namespace Samples.Dapper.Query
{
    public class QueryObject
    {
        public QueryObject(string sql)
        {
            Sql = sql;
        }

        public QueryObject(string sql, object queryParams) : this(sql)
        {
            QueryParams = queryParams;
        }

        public string Sql { get; private set; }

        public object QueryParams { get; private set; }
    }

    public class SelectProducts
    {
        public static QueryObject All()
        {
            return new QueryObject("select * from Products");
        }

        public static QueryObject ById(int id)
        {
            return new QueryObject("select * from Products where Id = @Id", new {Id = id});
        }
    }
}
