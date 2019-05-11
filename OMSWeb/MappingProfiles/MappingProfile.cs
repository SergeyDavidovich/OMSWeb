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
using OMSWeb.Api.Models.Shippers;


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
            CreateMap<Order, IndexOrderDto>()
                 .ForMember(dest => dest.CompanyName, val => val.MapFrom(src => src.Customer.CompanyName))
                 .ForMember(dest => dest.EmployeeName, val => val.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName));
            CreateMap<IndexOrderDto, Order>();

            CreateMap<Order, OrderDto>();

            // Customer
            CreateMap<Customer, IndexCustomerDto>();
            CreateMap<IndexCustomerDto, Customer>();

            // Employees
            CreateMap<Employee, IndexEmployeeDto>();
            CreateMap<IndexOrderDto, Employee>();

            // Suppliers
            CreateMap<Supplier, IndexSupplierDto>();
            CreateMap<IndexSupplierDto, Supplier>();

            // Shippers
            CreateMap<Shipper, IndexShipperDto>();
            CreateMap<IndexShipperDto, Shipper>();

            //CreateMap<Product, ProductModel>().ForMember("namme of added member",
            //    val => val.MapFrom(c => new String("any strting or string operation")));
        }
    }
}
