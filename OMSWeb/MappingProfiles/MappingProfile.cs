using OMSWeb.Api.Models.Products;
using OMSWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OMSWeb.Api.Models.Categories;
using OMSWeb.Api.Models.Orders;
using OMSWeb.Api.Models.Customers;
using OMSWeb.Api.Models.Employees;
using OMSWeb.Api.Models.Suppliers;


namespace OMSWeb.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Order
            CreateMap<Order, IndexOrderDto>();
            CreateMap<IndexOrderDto, Order>();

            // Customer
            CreateMap<Customer, IndexCustomerDto>();
            CreateMap<IndexCustomerDto, Customer>();

            // Employees
            CreateMap<Employee, IndexEmployeeDto>();
            CreateMap<IndexOrderDto, Employee>();

            // Suppliers
            CreateMap<Supplier, IndexSupplierDto>();
            CreateMap<IndexSupplierDto, Supplier>();


            //CreateMap<Product, ProductModel>().ForMember("namme of added member",
            //    val => val.MapFrom(c => new String("any strting or string operation")));
        }
    }
}
