using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesQueryProcessor _query;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        //GET: api/categories/2
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories(bool included)
        {
            var result = _query.Get(included);
            var items =
                _mapper.Map<IEnumerable<Category>, List<Category>>(result);
            return items;
        }
        //GET: api/categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id, bool include)
        {
            var item = _query.Get(id,include);
            //var product = _mapper.Map<ProductModel>(item);
            return item;
        }
        // POST: api/products
        [HttpPost]
        public async Task<Category> Post([FromBody]Category requestModel)
        {
            var item = await _query.CreateAsync(requestModel);
            //var model = _mapper.Map<Category>(item);
            return item;
        }


    }
}
