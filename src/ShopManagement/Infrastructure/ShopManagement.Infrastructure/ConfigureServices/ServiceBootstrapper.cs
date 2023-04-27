using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.ProductCategory;
using ShopManagement.Persistence;

namespace ShopManagement.Infrastructure.ConfigureServices
{
    public static class Bootstrapper
    {
        public static void ShopManagementBootstrapper(this IServiceCollection services, IConfiguration configuration)
        {
            // Database 
            services.AddDbContext<ShopManagementContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionDefault")));

            services.ShopManagementBootstrapRepositories();
            services.ShopManagementAppLayerServicesBootstrapper();
        }
    }
}
