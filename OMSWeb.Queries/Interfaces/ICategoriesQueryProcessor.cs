using OMSWeb.Api.Models.Categories;
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
        IQueryable<Category> Get();
        Category Get(int id);
        Task<Category> CreateAsync(CreateCategoryDto model);
        Task<Product> Update(int id, CreateCategoryDto model);
        //Task Delete(int id);
    }
}
