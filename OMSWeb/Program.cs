//https://www.toptal.com/asp-dot-net/asp-net-web-api-tutorial

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

//TODO: Implementing Cashing
//TODO: Implementing Authentification and Authorisation
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
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Hour)
            //.WriteTo.RollingFile("Logs\\Web-{Date}.log", outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
