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
using OMSWeb.Api.Models.OrderDetails;


namespace OMSWeb.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Order
            CreateMap<Order, IndexOrderDto>();
            CreateMap<IndexOrderDto, Order>();

            CreateMap<Order, OrderDto>().ForMember(src => src.OrderDetailsDto, val => val.MapFrom(src => src.OrderDetails));

            CreateMap<Order, OrderInvoiceDto>()
                  .ForMember(dest => dest.EmployeeName,
                  val => val.MapFrom(
                      src => src.Employee.FirstName + " " + src.Employee.LastName))
                  .ForMember(dest => dest.CompanyName,
                  val => val.MapFrom(src => src.Customer.CompanyName));

            // OrderDetail
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>();


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

        }
    }
}
