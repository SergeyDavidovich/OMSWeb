using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSWeb.Api.Models.Categories;
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
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var result = _query.Get();
            var items =
                _mapper.Map<IEnumerable<Category>, List<CategoryDto>>(result);
            return items;
        }

        //GET: api/categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(int id)
        {
            var item = _query.Get(id);
            var category = _mapper.Map<Category, CategoryDto>(item);
            return category;
        }

        // POST: api/products
        [HttpPost]
        public async Task<CategoryDto> Post([FromBody]CreateCategoryDto requestModel)
        {
            var item = await _query.CreateAsync(requestModel);
            var model = _mapper.Map<CategoryDto>(item);
            return model;
        }
    }
}
