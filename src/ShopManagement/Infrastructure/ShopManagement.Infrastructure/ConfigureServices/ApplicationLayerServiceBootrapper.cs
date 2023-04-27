using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.Facade;
using ShopManagement.Application.Contract.ProductApplication;
using ShopManagement.Application.Contract.ProductCategoryApplication;
using ShopManagement.Application.ProductApplication;
using ShopManagement.Application.ProductCategory;
using ShopManagement.Infrastructure.Facade;

namespace ShopManagement.Infrastructure.ConfigureServices;

public static class ApplicationLayerServiceBootrapper
{
     internal static void ShopManagementAppLayerServicesBootstrapper(this IServiceCollection services)
    {
        services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
        services.AddTransient<IProductApplication, ProductApplication>();
        services.AddTransient<IShopManagementFacade, ShopManagementFacade>();
    }
}