using System.Collections.Generic;
using Samples.Dapper.DataAccess.CommandQuery;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess.Query
{
    public class MssqlProductQueries : IProductQueries
    {
        public QueryObject SelectAll()
        {
            return new QueryObject("select * from Products");
        }

        public QueryObject SelectById(int id)
        {
            return new QueryObject(SelectAll().Sql + " where Id = @Id", new { Id = id });
        }

        public QueryObject Insert(ProductDto product)
        {
            return new QueryObject(@"insert into Products(Name, Description, Price) values (@Name, @Description, @Price);
                                     SELECT * FROM Products WHERE id = SCOPE_IDENTITY();", 
                                     new { product.Name, product.Description, product.Price });
        }

        public QueryObject UpdateName(int id, string newName)
        {
            return new QueryObject(@"update Products set Name = @Name where Id = @Id", 
                new { Name = newName, Id = id });
        }

        public QueryObject Delete(int? id)
        {
            var queryText = "delete from Products";
            if (id != null)
                queryText += "where Id = @Id";
            return new QueryObject(queryText, new {Id = id});
        }

        public QueryObject CreateTable()
        {
            return new QueryObject(@"CREATE TABLE [dbo].[Products] (
                    [Id]          INT            IDENTITY (1, 1) NOT NULL,
                    [Name]        NVARCHAR (MAX) NOT NULL,
                    [Description] NVARCHAR (MAX) NULL,
                    [Price]       FLOAT (53)     NULL,
                    [Created]     DATETIME       NOT NULL)");
        }

        public QueryObject DropTable()
        {
            return new QueryObject("DROP TABLE [dbo].[Products]");
        }
    }
}