using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSWeb.Api.Models.Customers;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersQueryProcessor _query;
        private readonly IMapper _mapper;

        public CustomersController(ICustomersQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/customers/2
        [HttpGet]
        public ActionResult<IEnumerable<IndexCustomerDto>> GetCustomers()
        {
            var result = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Customer>, List<IndexCustomerDto>>(result);
            return items;
        }
    }
}
