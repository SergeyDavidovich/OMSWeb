using OMSWeb.Api.Models.Products;
using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace OMSWeb.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            
            
            //CreateMap<Product, ProductModel>().ForMember("ModelType",
            //    val => val.MapFrom(c => new String("ProductModel")));
        }
    }
}
