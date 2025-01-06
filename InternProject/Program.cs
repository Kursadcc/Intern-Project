using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity.SqlServer;
//using Lamar.Microsoft.DependencyInjection;


namespace InternProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
           //.UseLamar()
           //.UseKestrel()
           .UseIISIntegration()
           .UseIIS()
           .UseStartup<Startup>();
    }
}
