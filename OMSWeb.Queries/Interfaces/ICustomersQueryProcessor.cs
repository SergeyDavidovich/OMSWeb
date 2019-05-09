using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMSWeb.Queries.Interfaces
{
    public interface ICustomersQueryProcessor
    {
        System.Linq.IQueryable<Customer> Get();
        Customer Get(string id);
    }
}
