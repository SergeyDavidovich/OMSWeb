using OMSWeb.Api.Models.Products;
using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSWeb.Queries.Queries
{
   public interface IProductsQueryProcessor
    {
        IQueryable<Product> Get();
        Product Get(int id);
        Task<Product> CreateAsync(CreateProductDto model);
        Task<Product> Update(int id, UpdateProductDto model);
        Task Delete(int id);
    }
}
