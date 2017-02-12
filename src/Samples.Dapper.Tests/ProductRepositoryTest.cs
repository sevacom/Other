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
        protected IProductRepository Target;

        [SetUp]
        public virtual void Setup()
        {
            var factory = new MssqlConnectionFactory();
            Target = new ProductRepositoryWithQueryObject(new Database(factory), factory);
        }

        [TearDown]
        public void TearDown()
        {
            Target.Delete();
        }

        [Test]
        public void ShouldGetProducts()
        {
            var expectedProduct = new ProductDto
            {
                Id = -1,
                Name = "Milk1"
            };

            Target.Add(expectedProduct);

            var actualProducts = Target.GetProducts();
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

            var actualInsertedProduct = Target.Add(expectedProduct);
            var actualSelectedProduct = Target.GetProduct(actualInsertedProduct.Id);

            actualInsertedProduct.Id.Should().BePositive();
            actualInsertedProduct.Created.Should().BeAfter(DateTime.MinValue);
            actualInsertedProduct.ShouldBeEquivalentTo(expectedProduct,
               options => options.Excluding(dto => dto.Id).Excluding(dto => dto.Created));

            actualSelectedProduct.Should().NotBeNull();
            actualSelectedProduct.ShouldBeEquivalentTo(actualInsertedProduct);
        }
    }

    [TestFixture]
    public class ProductRepositoryWithCommandQueryTest : ProductRepositoryTest
    {
        [SetUp]
        public override void Setup()
        {
            Target = new ProductRepositoryWithCommandQuery(
                new Database(new MssqlConnectionFactory()));
        }
    }
}