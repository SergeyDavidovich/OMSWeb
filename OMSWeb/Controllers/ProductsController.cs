using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSWeb.Api.Models.Products;
//using Microsoft.EntityFrameworkCore;
//using OMSWeb.Model;
//using OMSWeb.Data;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;
using AutoMapper.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsQueryProcessor _query;
        private readonly IMapper _mapper;

        public ProductsController(IProductsQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var result = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Product>, List<ProductDto>>(result);
            return items;
        }

        //GET: api/product/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var item = _query.Get(id);
            var product = _mapper.Map<ProductDto>(item);
            return product;
        }
        // POST: api/products
        [HttpPost]
        public async Task<ProductDto> Post([FromBody]CreateProductDto requestModel)
        {
            var item = await _query.CreateAsync(requestModel);
            var model = _mapper.Map<ProductDto>(item);
            return model;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody]UpdateProductDto requestModel)
        {
            var item = await _query.Update(id, requestModel);
            var model = _mapper.Map<ProductDto>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _query.Delete(id);
        }
    }
}
