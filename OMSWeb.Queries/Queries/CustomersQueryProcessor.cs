using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMSWeb.Queries.Queries
{
    public class CustomersQueryProcessor : ICustomersQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public CustomersQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<Customer> Get()
        {
            return GetQuery();
        }

        public Customer Get(string id)
        {
            var item = GetQuery().FirstOrDefault(p => p.CustomerId == id);
            return item;
        }

        private IQueryable<Customer> GetQuery()
        {
            var query = _uow.Query<Customer>();
            return query;
        }

    }
}
