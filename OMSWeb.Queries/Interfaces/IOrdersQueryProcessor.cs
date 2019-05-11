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
        Order Get(int id);
        //Task<Order> CreateAsync(CreateOrderDto model);
        //Task<Product> Update(int id, UpdateOrderDto model);
        //Task Delete(int id);
    }
}
