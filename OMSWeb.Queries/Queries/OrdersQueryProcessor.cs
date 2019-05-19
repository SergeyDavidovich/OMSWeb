using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OMSWeb.Api.Common.Exceptions;

namespace OMSWeb.Queries.Queries
{
    public class OrdersQueryProcessor : IOrdersQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public OrdersQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IQueryable<Order> Get()
        {
            var query = GetQuery()
                .Include(o => o.Employee)
                .Include(o => o.Customer);
            return query;
        }
        public Order Get(int id)
        {
            var query = GetQuery()
                .Include(o => o.Employee)
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == id);

            if (query==null)
            {
                throw new NotFoundException($"Order {id} is not found");
            }
            return query;
        }
        public async Task<Order> CreateAsync(CreateOrderDto model)
        {
            var order = new Order
            {
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId
            };

            var details = model.OrderDetailDto.
                Select(d => new OrderDetail()
                {
                    OrderId = d.OrderId,
                    ProductId = d.ProductId,
                    UnitPrice = d.UnitPrice,
                    Quantity = d.Quantity,
                    Discount = d.Discount
                });

            order.OrderDetails = details.ToList<OrderDetail>();

            _uow.Add(order);
            await _uow.CommitAsync();

            return order;
        }

        private IQueryable<Order> GetQuery()
        {
            var query = _uow.Query<Order>();

            //if (!_securityContext.IsAdministrator)
            //{
            //    var userId = _securityContext.User.Id;
            //    q = q.Where(x => x.UserId == userId);
            //}

            return query;
        }
    }
}
