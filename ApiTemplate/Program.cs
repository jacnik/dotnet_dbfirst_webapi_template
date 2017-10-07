using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiTemplate
{
    public class Program
    {
        /*
         * Helpful links:
         * https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
         * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
         */
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
