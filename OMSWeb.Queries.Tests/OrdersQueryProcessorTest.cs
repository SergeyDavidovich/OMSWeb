using FluentAssertions;
using Moq;
using OMSWeb.Api.Common.Exceptions;
using OMSWeb.Api.Models.OrderDetails;
using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OMSWeb.Queries.Tests
{
    public class OrdersQueryProcessorTest
    {
        private Random _random;
        private Mock<IUnitOfWork> _uow;
        private List<Order> _orderList;
        private IOrdersQueryProcessor _query;

        public OrdersQueryProcessorTest()
        {
            _random = new Random();
            _uow = new Mock<IUnitOfWork>();

            _orderList = new List<Order>();
            _uow.Setup(x => x.Query<Order>()).Returns(() => _orderList.AsQueryable());

            _query = new OrdersQueryProcessor(_uow.Object);
        }
        [Fact]
        public void GetShouldReturnAll()
        {
            _orderList.Add(new Order { OrderId = _random.Next() });
            var result = _query.Get().ToList();
            result.Count.Should().Be(1);
        }
        [Fact]
        public void GetShouldReturnById()
        {
            var order = new Order { OrderId = _random.Next() };
            _orderList.Add(order);

            var result = _query.Get(order.OrderId);
            result.Should().Be(order);
        }
        [Fact]
        public async Task CreateShouldSaveNew()
        {
            var dto = new CreateOrderDto()
            {
                CustomerId = _random.Next().ToString().PadLeft(5),
                EmployeeId = _random.Next(),
                OrderDetailDto = new List<OrderDetailDto>()
                {
                    new OrderDetailDto()
                    {
                        ProductId =_random.Next(),
                        Quantity =(short)_random.Next(),
                        UnitPrice =_random.Next(),
                        Discount=_random.Next(1)
                    }
                }
            };
            var result = await _query.CreateAsync(dto);

            result.CustomerId.Should().Be(dto.CustomerId);
            result.EmployeeId.Should().Be(dto.EmployeeId);
            result.OrderDetails.Count().Should().Be(1);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void GetShouldThrowExceptionIfItemIsNotFoundById()
        {
            var order = new Order { OrderId = _random.Next() };
            _orderList.Add(order);

            Action get = () =>
            {
                _query.Get(_random.Next());
            };
            get.Should().Throw<NotFoundException>();
        }

    }
}
