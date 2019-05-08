using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
//using OMSWeb.Model;
//using OMSWeb.Data;

using NJsonSchema;
using NSwag.AspNetCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore;
using OMSWeb.Data.Access.DAL;
using OMSWeb.IoC;
using OMSWeb.Filters;

namespace OMSWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ContainerSetup.Setup(services,Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options => { options.Filters.Add(new ApiExceptionFilter()); })
              .AddJsonOptions(o =>
              {
                  o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
              });
            ;

            // Register the Swagger services
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


            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
