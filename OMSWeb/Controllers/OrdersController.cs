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

        // GET: api/orders/id
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

        // GET: api/invoices/id
        [HttpGet("Invoices/{id}")]
        public ActionResult<OrderInvoiceDto> GetInvoice(int id)
        {
            var orders = _query.Get(id);

            var item = _mapper.Map<Order, OrderInvoiceDto>(orders);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostProduct(CreateOrderDto requestModel)
        {
            var item = await _query.CreateAsync(requestModel);
            var model = _mapper.Map<OrderDto>(item);
            return model;
        }
    }
}



