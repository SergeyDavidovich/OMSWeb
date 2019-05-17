using FluentAssertions;
using Moq;
using OMSWeb.Api.Common.Exceptions;
using OMSWeb.Api.Models.Products;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace OMSWeb.Queries.Tests
{
    public class ProductsQueryProcessorTest
    {
        private Random _random;
        private Mock<IUnitOfWork> _uow;
        private List<Product> _productList;
        private IProductsQueryProcessor _query;

        //private User _currentUser;
        //private Mock<ISecurityContext> _securityContext;

        public ProductsQueryProcessorTest()
        {
            _random = new Random();
            _uow = new Mock<IUnitOfWork>();

            _productList = new List<Product>();
            _uow.Setup(x => x.Query<Product>()).Returns(() => _productList.AsQueryable());

            _query = new ProductsQueryProcessor(_uow.Object);

        }
        [Fact]
        public void GetShouldReturnAll()
        {
            _productList.Add(new Product { ProductId = _random.Next() });
            var result = _query.Get().ToList();
            result.Count.Should().Be(1);
        }
        [Fact]
        public void GetShouldReturnById()
        {
            var product = new Product { ProductId = _random.Next() };
            _productList.Add(product);

            var result = _query.Get(product.ProductId);
            result.Should().Be(product);
        }
        [Fact]
        public async Task CreateShouldSaveNew()
        {
            var model = new CreateProductDto()
            {
                ProductName = _random.Next().ToString(),
                UnitPrice = (Decimal)10.50,
                Discontinued = false
            };

            var result = await _query.CreateAsync(model);

            result.ProductName.Should().Be(model.ProductName);
            result.UnitPrice.Should().Be(model.UnitPrice);
            result.Discontinued.Should().Be(model.Discontinued);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
        }
        [Fact]
        public async Task UpdateShouldUpdateFields()
        {
            var product = new Product
            {
                ProductId = _random.Next(),
                ProductName = _random.Next().ToString(),
                UnitPrice = _random.Next()
            };
            _productList.Add(product);

            var model = new UpdateProductDto
            {
                UnitPrice = _random.Next(),
            };

            var result = await _query.Update(product.ProductId, model);

            result.Should().Be(product);
            result.UnitPrice.Should().Be(model.UnitPrice);

            _uow.Verify(x => x.CommitAsync());
        }
        [Fact]
        public async Task DeleteShouldMarkAsDiscontinued()
        {
            var product = new Product() { ProductId = _random.Next() };
            _productList.Add(product);

            await _query.Delete(product.ProductId);

            product.Discontinued.Should().BeTrue();

            _uow.Verify(x => x.CommitAsync());
        }
        [Fact]
        public void GetShouldThrowExceptionIfItemIsNotFoundById()
        {
            var expense = new Product { ProductId = _random.Next() };
            _productList.Add(expense);

            Action get = () =>
            {
                _query.Get(_random.Next());
            };

            get.Should().Throw<NotFoundException>();
        }
        [Fact]
        public void UpdateShoudlThrowExceptionIfItemIsNotFound()
        {
            Action create = () =>
            {
                var result = _query.Update(_random.Next(), new UpdateProductDto()).Result;
            };

            create.Should().Throw<NotFoundException>();
        }

        [Fact]
        public void DeleteShoudlThrowExceptionIfItemIsNotFound()
        {
            Action execute = () =>
            {
                _query.Delete(_random.Next()).Wait();
            };

            execute.Should().Throw<NotFoundException>();
        }
    }
}


