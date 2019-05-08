using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OMSWeb.Api.Models.Categories;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;

namespace OMSWeb.Queries.Queries
{
    public class CategoriesQueryProcessor : ICategoriesQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public CategoriesQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<Category> Get()
        {
            var query = GetQuery();
            return query;
        }

        public Category Get(int id)
        {
            var query = GetQuery().FirstOrDefault(c => c.CategoryId == id);

            return query;
        }

        public async Task<Category> CreateAsync(CreateCategoryDto dto)
        {
            var item = new Category
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description,
            };

            _uow.Add(item);
            await _uow.CommitAsync();

            return item;
        }

        public Task<Product> Update(int id, Product model)
        {
            throw new NotImplementedException();
        }
              
        private IQueryable<Category> GetQuery()
        {
            var query = _uow.Query<Category>();
            return query;
        }
    }
}
