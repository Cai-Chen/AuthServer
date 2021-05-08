using AuthServer.Configuration;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            // Add test data into database
            //using (var scope = host.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            //    TestDataConfig.AddConfigData(context);
            //}

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
