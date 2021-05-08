using AuthServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection ConfigIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
