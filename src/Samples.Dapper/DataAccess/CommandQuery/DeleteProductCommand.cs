using System.Data;
using Dapper;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess.CommandQuery
{
    public class DeleteProductCommand : ICommand
    {
        private readonly ProductDto _product;

        public DeleteProductCommand(ProductDto product)
        {
            _product = product;
        }

        public void Execute(IDbConnection db)
        {
            var queryText = "delete from Products";
            if (_product != null)
                queryText += "where Id = @Id";

            db.Execute(queryText, new {_product?.Id });
        }
    }
}