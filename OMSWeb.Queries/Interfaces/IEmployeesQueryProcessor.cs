using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMSWeb.Queries.Interfaces
{
    public interface IEmployeesQueryProcessor
    {
        System.Linq.IQueryable<Employee> Get();
        Employee Get(int id);

    }
}
