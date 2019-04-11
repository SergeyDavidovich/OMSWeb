//TODO: Delete the line below
//https://www.toptal.com/asp-dot-net/asp-net-web-api-tutorial

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace OMSWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseIISIntegration()
            //  .UseContentRoot(Directory.GetCurrentDirectory())
            //  .UseStartup<Startup>()
            //  .Build();

            //host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
