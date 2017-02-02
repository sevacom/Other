using System;
using FluentAssertions;
using NUnit.Framework;
using Samples.Dapper.DataAccess;
using Samples.Dapper.Dto;

namespace Samples.Dapper.Tests
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private ProductRepository _target;

        [SetUp]
        public void Setup()
        {
            _target = new ProductRepository(new MssqlConnectionFactory());
        }

        [TearDown]
        public void TearDown()
        {
            _target.Delete();
        }

        [Test]
        public void ShouldGetProducts()
        {
            var expectedProduct = new ProductDto
            {
                Id = -1,
                Name = "Milk"
            };

            _target.Add(expectedProduct);

            var actualProducts = _target.GetProducts();
            actualProducts.Should()
                .HaveCount(1)
                .And
                .OnlyContain(p => p.Name == expectedProduct.Name);
        }

        [Test]
        public void ShouldAddProduct()
        {
            var expectedProduct = new ProductDto
            {
                Id = -1,
                Name = "SimpleProduct",
                Description = "Description",
                Price = 12.5f
            };

            var actualInsertedProduct = _target.Add(expectedProduct);
            var actualSelectedProduct = _target.GetProduct(actualInsertedProduct.Id);

            actualInsertedProduct.Id.Should().BePositive();
            actualInsertedProduct.Created.Should().BeAfter(DateTime.MinValue);
            actualInsertedProduct.ShouldBeEquivalentTo(expectedProduct,
               options => options.Excluding(dto => dto.Id).Excluding(dto => dto.Created));

            actualSelectedProduct.Should().NotBeNull();
            actualSelectedProduct.ShouldBeEquivalentTo(actualInsertedProduct);
        }
    }
}