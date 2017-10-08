namespace ApiTemplate
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System;

    public class Program
    {
        /*
         * Helpful links:
         * https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
         * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
         * https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection
         * https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
         * https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
         * https://docs.microsoft.com/en-us/dotnet/core/testing/
         * https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing
         * https://andrewlock.net/introduction-to-integration-testing-with-xunit-and-testserver-in-asp-net-core/
         */
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
                .UseStartup<Startup>()
                .Build();
    }
}
