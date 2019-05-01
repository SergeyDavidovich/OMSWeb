using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSWeb.Queries.Queries
{
    public interface ICategoriesQueryProcessor
    {
        IQueryable<Category> Get(bool include);
        Category Get(int id, bool include);
        Task<Category> CreateAsync(Category model);
        Task<Product> Update(int id, Product model);
        //Task Delete(int id);
    }
}
