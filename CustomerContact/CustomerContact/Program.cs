using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerContact
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            //var host = CreateWebHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var serviceProvider = scope.ServiceProvider;

            //    var hostingEnv = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();

            //    var config = new ConfigurationBuilder()
            //                        .SetBasePath(hostingEnv.ContentRootPath)
            //                        .AddJsonFile($"appsettings.{hostingEnv.EnvironmentName}.json")
            //                        .AddEnvironmentVariables()
            //                        .Build();
            //}
            //host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //       WebHost.CreateDefaultBuilder(args)
        //           .UseIIS()
        //           .UseStartup<Startup>()

        //           ;
        //}
    }
}
