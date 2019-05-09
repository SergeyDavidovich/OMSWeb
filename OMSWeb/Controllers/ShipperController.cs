using Microsoft.AspNetCore.Mvc;
using OMSWeb.Data.Access.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMSWeb.Api.Models.Shippers;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Interfaces;
using AutoMapper;



namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShippersQueryProcessor _query;
        private readonly IMapper _mapper;

        public ShippersController(IShippersQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/shippers/
        [HttpGet]
        public ActionResult<IEnumerable<IndexShipperDto>> GetShipperss()
        {
            var result = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Shipper>, List<IndexShipperDto>>(result);
            return items;
        }
    }
}
