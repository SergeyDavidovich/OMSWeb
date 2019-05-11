using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == id);
            return query;
        }

        //public Task<Order> CreateAsync(CreateOrderDto model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Product> Update(int id, UpdateOrderDto model)
        //{
        //    throw new NotImplementedException();
        //}

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
