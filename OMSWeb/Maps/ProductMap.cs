using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using OMSWeb.Data.Model;
using OMSWeb.Api.Models.Products;

namespace OMSWeb.Maps
{
    public class ProductMap
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<Product, GetProductModel>();
        }
    }
}
