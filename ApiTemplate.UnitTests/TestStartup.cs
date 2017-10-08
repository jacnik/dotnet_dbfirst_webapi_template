namespace ApiTemplate.UnitTests
{
    using ApiTemplate.ContosoUniversity.DAL;
    using ApiTemplate.ContosoUniversity.DAL.Models;
    using ApiTemplate.Controllers;
    using ApiTemplate.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * Register types from this solution
             */
            services.AddTransient<ContosoRepository>()
                    .AddDbContext<SchoolContext>(options => options.UseInMemoryDatabase("TestContosoDatabase")); ;
            services.AddTransient<ISchoolRepository, SchoolRepository>();

            /*
             * Register general services
             */
            services
                .AddMvc()
                // this is explained here: https://stackoverflow.com/a/43669661
                .AddApplicationPart(Assembly.Load(new AssemblyName("ApiTemplate")))
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
