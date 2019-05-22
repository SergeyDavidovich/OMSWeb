using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

//TODO: Implementing Logging
//TODO: Implementing Cashing
//TODO: Implementing Authentifikation and Authorisation
//TODO: Implementing Migrations
//TODO: Add CategoriesQueryProcessorTest
//TODO: Add CustomersQueryProcessorTest
//TODO: Add EmoloyeesQueryProcessorTest
//TODO: Add ShippersQueryProcessorTest
//TODO: Add SuppliersQueryProcessorTest

namespace OMSWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseStartup<Startup>()
              .Build();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
