using System.Data;
using System.Linq;
using Dapper;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess.CommandQuery
{
    public class CreateProductCommand : ICommand<ProductDto>
    {
        private readonly ProductDto _product;

        public CreateProductCommand(ProductDto product)
        {
            _product = product;
        }

        public ProductDto Execute(IDbConnection db)
        {
            var res =
                db.Query<ProductDto>(@"insert into Products(Name, Description, Price) values (@Name, @Description, @Price);
                                     SELECT * FROM Products WHERE id = SCOPE_IDENTITY();",
                    new {_product.Name, _product.Description, _product.Price}).Single();

            return res;
        }
    }
}