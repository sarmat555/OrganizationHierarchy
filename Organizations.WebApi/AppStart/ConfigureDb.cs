using Microsoft.EntityFrameworkCore;
using Organizations.Application.Context;

namespace Organizations.WebApi.AppStart
{
    public static class ConfigureDb
    {
        /// <summary>
        /// добавляем контекст ApplicationContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="conf"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationContext(this IServiceCollection services, IConfiguration conf) 
        {
            string connection = conf.GetConnectionString("DefaultConnection")!;

            services.AddDbContext<ApplicationContext>(options => {

                options.UseNpgsql(connection);
                options.UseSnakeCaseNamingConvention();//настраиваем snake_case

            });
            return services;
        }
    }
}
