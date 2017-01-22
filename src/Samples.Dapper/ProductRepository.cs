using System;
using System.Collections.Generic;
using Samples.Dapper.Dto;
using Samples.Dapper.Query;

namespace Samples.Dapper
{
    public class ProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            using (var connection = _connectionFactory.Create())
            {
                return connection.Query<ProductDto>(SelectProducts.All());
            }
        }
    }
}