using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
//using OMSWeb.Model;
//using OMSWeb.Data;
using Newtonsoft.Json;
using OMSWeb.Api.Models.Orders;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;

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
        public async Task<ActionResult<Order>> GetOrder(int id, bool include_details = false)
        {
            var orders = include_details ?
                await _query.Get().Include(o => o.OrderDetails).ToListAsync<Order>() : await _query.Get().ToListAsync<Order>();

            var order = orders.Where(o => o.OrderId == id).FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }
            return order;
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



