using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OMSWeb.Data.Access.DAL;
using OMSWeb.Queries.Queries;
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
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper();
        }

    }
}
