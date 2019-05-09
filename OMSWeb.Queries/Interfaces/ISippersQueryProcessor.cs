using System;
using System.Collections.Generic;
using System.Text;
using OMSWeb.Data.Model;


namespace OMSWeb.Queries.Interfaces
{
    public interface IShippersQueryProcessor
    {
        System.Linq.IQueryable<Shipper> Get();
        Shipper Get(int id);
    }
}
