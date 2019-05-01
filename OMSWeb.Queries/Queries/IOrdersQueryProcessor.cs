using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSWeb.Queries.Queries
{
    public interface IOrdersQueryProcessor
    {
        IQueryable<Order> Get();
        Product Get(int id);
        Task<Product> CreateAsync(CreateOrderModel model);
        Task<Product> Update(int id, UpdateOrderModel model);
        Task Delete(int id);
    }
}
