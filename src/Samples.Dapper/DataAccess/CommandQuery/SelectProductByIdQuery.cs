using System.Data;
using System.Linq;
using Dapper;
using Samples.Dapper.DataAccess.Query;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess.CommandQuery
{
    public class SelectProductByIdQuery : IQuery<ProductDto>
    {
        private readonly int _id;

        public SelectProductByIdQuery(int id)
        {
            _id = id;
        }

        public ProductDto Execute(IDbConnection db)
        {
            return db.Query<ProductDto>("select * from Products where Id = @Id", new {Id = _id})
                .FirstOrDefault();
        }
    }
}