using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using OMSWeb.Model;
//using OMSWeb.Data;
using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersQueryProcessor _query;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/orders
        [HttpGet]
        public ActionResult<IEnumerable<IndexOrderDto>> GetOrders()
        {
            var orders = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Order>, List<IndexOrderDto>>(orders);
            return items;
        }

        // GET: api/orders/5?include = true/false
        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var orders = _query.Get(id);

            var item = _mapper.Map<Order, OrderDto>(orders);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //    // POST: api/products
        //    [HttpPost]
        //    public async Task<ActionResult<Orders>> PostProduct(Orders order)
        //    {
        //        _context.Orders.Add(order);

        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetOrder),
        //            new
        //            {
        //                id = order.OrderId,
        //                orderDate = order.OrderDate
        //            },
        //            order);
        //    }

    }
}



