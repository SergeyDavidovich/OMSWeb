using System;
using System.Collections.Generic;
using System.Text;
using OMSWeb.Data.Model;

namespace OMSWeb.Queries.Interfaces
{
    public interface ISuppliersQueryProcessor
    {
        System.Linq.IQueryable<Supplier> Get();
        Supplier Get(int id);
    }
}
