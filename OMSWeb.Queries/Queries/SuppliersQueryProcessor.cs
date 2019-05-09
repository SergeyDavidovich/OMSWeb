using System;
using System.Collections.Generic;
using System.Text;
using OMSWeb.Queries.Interfaces;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using System.Linq;

namespace OMSWeb.Queries.Queries
{
    public class SuppliersQueryProcessor : ISuppliersQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public SuppliersQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IQueryable<Supplier> Get()
        {
            return GetQuery();
        }

        public Supplier Get(int id)
        {
            var item = GetQuery().FirstOrDefault(p => p.SupplierId == id);
            return item;
        }

        private IQueryable<Supplier> GetQuery()
        {
            var query = _uow.Query<Supplier>();
            return query;
        }
    }
}
