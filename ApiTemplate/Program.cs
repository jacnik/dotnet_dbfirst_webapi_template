namespace ApiTemplate
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        /*
         * Helpful links:
         * https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
         * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
         * https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection
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
