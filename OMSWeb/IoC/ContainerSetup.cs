using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OMSWeb.Data.Access.DAL;
using OMSWeb.Queries.Queries;
using OMSWeb.Queries.Interfaces;
using AutoMapper;

namespace OMSWeb.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            AddUow(services, configuration);
            AddQueries(services);
            ConfigureAutoMapper(services);
            RegisterSwapper(services);
        }

        private static void RegisterSwapper(IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "OMS Web API";
                    document.Info.Description = "Backend for Order Managment System";
                    //document.Info.TermsOfService = "None";

                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Stupeni .NET",
                        Email = "writesd@hotmail.com",
                        Url = "https://github.com/StupeniNET/OMSWebService"
                    };

                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under Apache 2.0 Licence",
                        Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                    };
                };
            });
        }

        private static void AddUow(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("OMSDatabase");
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IUnitOfWork>(ctx => new EFUnitOfWork(ctx.GetRequiredService<NorthwindContext>()));
        }

        private static void AddQueries(IServiceCollection services)
        {
            services.AddScoped<IProductsQueryProcessor, ProductsQueryProcessor>();
            services.AddScoped<IOrdersQueryProcessor, OrdersQueryProcessor>();
            services.AddScoped<ICategoriesQueryProcessor, CategoriesQueryProcessor>();
            services.AddScoped<ICustomersQueryProcessor, CustomersQueryProcessor>();
            services.AddScoped<IEmployeesQueryProcessor, EmployeeQueryProcessor>();
            services.AddScoped<ISuppliersQueryProcessor, SuppliersQueryProcessor>();
            services.AddScoped<IShippersQueryProcessor, ShippersQueryProcessor>();
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper();
        }

    }
}
