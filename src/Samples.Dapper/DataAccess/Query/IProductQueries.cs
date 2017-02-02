using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess.Query
{
    public interface IProductQueries
    {
        QueryObject SelectAll();

        QueryObject SelectById(int id);

        QueryObject Insert(ProductDto product);

        QueryObject CreateTable();

        QueryObject DropTable();

        QueryObject UpdateName(int id, string newName);

        QueryObject Delete(int? id);
    }
}