using AuthServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthServer.Configuration
{
    public static class IdentityServerConfig
    {
        public static IServiceCollection ConfigIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("Default"),
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("Default"),
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddAspNetIdentity<AppUser>();

            return services;
        }
    }
}
