using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
//using OMSWeb.Model;
//using OMSWeb.Data;
using Newtonsoft.Json;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;

namespace OMSWeb.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class OrdersController : ControllerBase
    //{
    //    private readonly NorthwindContext _context;

    //    public OrdersController(NorthwindContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/orders?include_details=true
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Orders>>> GetOrders(bool include_details = false)
    //    {
    //        List<Orders> orders;

    //        if (include_details)
    //            orders = await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
    //        else
    //            orders = await _context.Orders.ToListAsync();

    //        return orders;
    //    }

    //    // GET: api/orders/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Orders>> GetOrder(int id, bool include_details = false)
    //    {
    //        var orders = include_details ?
    //            await _context.Orders.Include(o => o.OrderDetails).ToListAsync<Orders>() : await _context.Orders.ToListAsync<Orders>();

    //        var order = orders.Where(o => o.OrderId == id).FirstOrDefault();

    //        if (order == null)
    //        {
    //            return NotFound();
    //        }
    //        return order;
    //    }

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

    //}
}



