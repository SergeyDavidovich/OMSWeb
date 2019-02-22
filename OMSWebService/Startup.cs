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
using OMSWebService.Model;
using OMSWebService.Data;

using NJsonSchema;
using NSwag.AspNetCore;

namespace OMSWebService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //TODO: Разобраться с подключением ДБ
            string connection =
                @"Data Source = (localdb)\mssqllocaldb; AttachDbFilename = C:\GitHubMy\OMSWebService\OMSWebService\App_Data\NORTHWND.MDF; Integrated Security = True";

            //string connection = @"Data Source = (localdb)\mssqllocaldb; AttachDbFilename = |DataDirectory|\NORTHWND.MDF; Integrated Security = True";

            services.AddDbContext<NORTHWNDContext>(options => options.UseSqlServer(connection));

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "OMS Web Service API";
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
