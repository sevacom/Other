using System.Collections.Generic;
using System.Data;
using Dapper;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess.CommandQuery
{
    public class SelectAllProducts : IQuery<IEnumerable<ProductDto>>
    {
        public IEnumerable<ProductDto> Execute(IDbConnection db)
        {
            return db.Query<ProductDto>("select * from Products");
        }
    }
}