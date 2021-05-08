using AuthServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConfigDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}
