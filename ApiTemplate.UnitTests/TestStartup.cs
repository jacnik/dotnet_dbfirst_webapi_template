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

            /*
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddContosoUniversity(connection);
            */
            services.AddTransient<ContosoRepository>()
                    .AddDbContext<SchoolContext>(options => options.UseInMemoryDatabase("TestContosoDatabase")); ;

            services.AddTransient<StudentsController>();
            services.AddTransient<ValuesController>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();

            /*
             * Register general services
             */
            var t = new AssemblyName("ApiTemplate");

            var r = Assembly.Load(t);

            services
                .AddMvc()
                //.AddApplicationPart(Assembly.Load(new AssemblyName("ApiTemplate.Controllers")))
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
