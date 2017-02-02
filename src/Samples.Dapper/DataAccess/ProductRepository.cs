using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Dapper.DataAccess.Query;
using Samples.Dapper.Dto;

namespace Samples.Dapper.DataAccess
{
    public class ProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IProductQueries _productQueries;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            _connectionFactory = connectionFactory;
            _productQueries = _connectionFactory.QueriesProvider.ProductQueries;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            using (var connection = _connectionFactory.Create())
            {
                return connection.Query<ProductDto>(_productQueries.SelectAll());
            }
        }

        public ProductDto GetProduct(int id)
        {
            using (var connection = _connectionFactory.Create())
            {
                return connection.Query<ProductDto>(_productQueries.SelectById(id)).FirstOrDefault();
            }
        }

        public ProductDto Add(ProductDto product)
        {
            using (var connection = _connectionFactory.Create())
            {
                return connection.Query<ProductDto>(_productQueries.Insert(product)).Single();
            }
        }

        public bool Delete(ProductDto product = null)
        {
            using (var connection = _connectionFactory.Create())
            {
                var res = connection.Execute(_productQueries.Delete(product?.Id));
                return res > 0;
            }
        }
    }
}