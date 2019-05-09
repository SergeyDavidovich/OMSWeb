using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Interfaces;

namespace OMSWeb.Queries.Queries
{
    public class EmployeeQueryProcessor : IEmployeesQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public EmployeeQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IQueryable<Employee> Get()
        {
            return GetQuery();
        }

        public Employee Get(int id)
        {
            var item = GetQuery().FirstOrDefault(p => p.EmployeeId == id);
            return item;
        }

        private IQueryable<Employee> GetQuery()
        {
            var query = _uow.Query<Employee>();
            return query;
        }
    }
}
