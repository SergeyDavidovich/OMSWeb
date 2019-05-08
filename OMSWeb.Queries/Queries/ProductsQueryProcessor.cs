using OMSWeb.Api.Common.Exceptions;
using OMSWeb.Api.Models.Products;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWeb.Queries.Queries
{
    public class ProductsQueryProcessor : IProductsQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public ProductsQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<Product> Get()
        {
            var query = GetQuery();
            return query;
        }

        public Product Get(int id)
        {
            var item = GetQuery().FirstOrDefault(p => p.ProductId == id);
            return item;
        }

        public async Task<Product> CreateAsync(CreateProductModel model)
        {
            var item = new Product
            {
                ProductName = model.ProductName,
                SupplierId = model.SupplierId,
                CategoryId = model.CategoryId,
                QuantityPerUnit = model.QuantityPerUnit,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                ReorderLevel = model.ReorderLevel
            };
            _uow.Add(item);
            await _uow.CommitAsync();
            return item;
        }
        public async Task<Product> Update(int id, UpdateProductModel model)
        {
            var item = GetQuery().FirstOrDefault(x => x.ProductId == id);

            if (item == null)
            {
                throw new NotFoundException("Product is not found");
            }

            item.ProductName = model.ProductName;
            item.UnitPrice = model.UnitPrice;

            item.QuantityPerUnit = model.QuantityPerUnit;
            item.ReorderLevel = model.ReorderLevel;

            await _uow.CommitAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var item = GetQuery().FirstOrDefault(u => u.ProductId == id);

            if (item == null)
            {
                throw new NotFoundException("Product is not found");
            }

            if (item.Discontinued) return;

            item.Discontinued = true;
            await _uow.CommitAsync();
        }

        private IQueryable<Product> GetQuery()
        {
            var query = _uow.Query<Product>()
                .Where(x => !x.Discontinued);

            //if (!_securityContext.IsAdministrator)
            //{
            //    var userId = _securityContext.User.Id;
            //    q = q.Where(x => x.UserId == userId);
            //}

            return query;
        }
    }
}
