namespace ApiTemplate.ContosoUniversity.DAL
{
    using ApiTemplate.ContosoUniversity.DAL.Models;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterTypes
    {
        public static IServiceCollection AddContosoUniversity(this IServiceCollection services)
            => services.AddTransient<SchoolContext>();
    }
}
