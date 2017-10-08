namespace ApiTemplate.ContosoUniversity.DAL
{
    using ApiTemplate.ContosoUniversity.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterTypes
    {
        public static IServiceCollection AddContosoUniversity(this IServiceCollection services, string connection)
        {
            return services.AddTransient<ContosoRepository>()
                           .AddDbContext<SchoolContext>(options =>
                               options.UseSqlServer(connection));
        }
    }
}
