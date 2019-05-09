using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Interfaces;

namespace OMSWeb.Queries.Queries
{
    public class ShippersQueryProcessor : IShippersQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public ShippersQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IQueryable<Shipper> Get()
        {
            return GetQuery();
        }

        public Shipper Get(int id)
        {
            var item = GetQuery().FirstOrDefault(p => p.ShipperId == id);
            return item;
        }

        private IQueryable<Shipper> GetQuery()
        {
            var query = _uow.Query<Shipper>();
            return query;
        }
    }
}
