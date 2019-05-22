using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMSWeb.Queries.Interfaces;
using AutoMapper;
using OMSWeb.Api.Models.Suppliers;
using OMSWeb.Data.Model;


namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersQueryProcessor _query;
        private readonly IMapper _mapper;

        public SuppliersController(ISuppliersQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/suppliers/
        [HttpGet]
        public ActionResult<IEnumerable<IndexSupplierDto>> GetSuppliers()
        {
            var result = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Supplier>, List<IndexSupplierDto>>(result);
            return items;
        }
    }
}
