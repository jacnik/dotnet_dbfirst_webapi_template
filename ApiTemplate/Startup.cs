namespace ApiTemplate
{
    using ApiTemplate.ContosoUniversity.DAL;
    using ApiTemplate.SchoolModel;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
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
            // See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddContosoUniversity(connection);
            services.AddTransient<ISchoolRepository, SchoolRepository>();

            /*
             * Register general services
             */
            services
                .AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
