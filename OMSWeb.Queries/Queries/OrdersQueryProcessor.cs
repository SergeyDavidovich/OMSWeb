using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;

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
            var query = GetQuery();
            return query;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateAsync(CreateOrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(int id, UpdateOrderModel model)
        {
            throw new NotImplementedException();
        }
        private IQueryable<Order> GetQuery()
        {
            var q = _uow.Query<Order>();

            //if (!_securityContext.IsAdministrator)
            //{
            //    var userId = _securityContext.User.Id;
            //    q = q.Where(x => x.UserId == userId);
            //}

            return q;
        }
    }
}
