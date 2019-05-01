using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Category> Get(bool include)
        {
            var query = GetQuery(include);
            return query;
        }

        public Category Get(int id, bool include)
        {
            var query = GetQuery(include).FirstOrDefault(c => c.CategoryId == id);

            return query;
        }

        private IQueryable<Category> GetQuery(bool include)
        {
            var query = (include) ? _uow.Query<Category>().Include(e => e.Products) : _uow.Query<Category>();

            //if (!_securityContext.IsAdministrator)
            //{
            //    var userId = _securityContext.User.Id;
            //    q = q.Where(x => x.UserId == userId);
            //}

            return query;
        }
        public async Task<Category> CreateAsync(Category model)
        {
            var item = new Category
            {
                CategoryName = model.CategoryName,
            };

            _uow.Add(item);
            await _uow.CommitAsync();

            return item;
        }

        public Task<Product> Update(int id, Product model)
        {
            throw new NotImplementedException();
        }
    }
}
