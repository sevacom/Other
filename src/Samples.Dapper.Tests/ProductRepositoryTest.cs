using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Samples.Dapper.DataAccess;

namespace Samples.Dapper.Tests
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        [Test]
        public void ShouldGetProducts()
        {
            var target = new ProductRepository(new MssqlConnectionFactory());

            var actualPruducts = target.GetAllProducts().ToArray();

            actualPruducts.Should().HaveCount(2);
        }
    }
}