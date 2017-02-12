using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Dapper.DataAccess.CommandQuery;
using Samples.Dapper.DataAccess.Query;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetProducts();
        ProductDto GetProduct(int id);
        ProductDto Add(ProductDto product);
        bool Delete(ProductDto product = null);
    }

    public class ProductRepositoryWithQueryObject : IProductRepository
    {
        private readonly IDatabase _database;
        private readonly IProductQueries _productQueries;

        public ProductRepositoryWithQueryObject(IDatabase database, IQueryBuilder queryBuilder)
        {
            if (database == null) throw new ArgumentNullException(nameof(database));
            if (queryBuilder == null) throw new ArgumentNullException(nameof(queryBuilder));
            _productQueries = queryBuilder.ProductQueries;
            _database = database;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _database.Execute<ProductDto>(_productQueries.SelectAll());
        }

        public ProductDto GetProduct(int id)
        {
            return _database.Execute<ProductDto>(_productQueries.SelectById(id))
                .FirstOrDefault();
        }

        public ProductDto Add(ProductDto product)
        {
            return _database.Execute<ProductDto>(_productQueries.Insert(product)).Single();
        }

        public bool Delete(ProductDto product = null)
        {
            var res = _database.Execute(_productQueries.Delete(product?.Id));
            return res > 0;
        }
    }

    public class ProductRepositoryWithCommandQuery: IProductRepository
    {
        private readonly IDatabase _database;

        public ProductRepositoryWithCommandQuery(IDatabase database)
        {
            if (database == null) throw new ArgumentNullException(nameof(database));
            _database = database;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _database.Execute(new SelectAllProducts());
        }

        public ProductDto GetProduct(int id)
        {
            return _database.Execute(new SelectProductByIdQuery(id));
        }

        public ProductDto Add(ProductDto product)
        {
            return _database.Execute(new CreateProductCommand(product));
        }

        public bool Delete(ProductDto product = null)
        {
            _database.Execute(new DeleteProductCommand(product));
            return true;
        }
    }
}