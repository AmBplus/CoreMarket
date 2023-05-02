using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.Facade;
using ShopManagement.Application.Contract.ProductApplication;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ShopManagement.Infrastructure.Facade;

public class ShopManagementFacade : IShopManagementFacade
{
	// Use ServiceLocator Pattern
	public ShopManagementFacade(IServiceProvider serviceProvider)
	{
        ServiceProvider = serviceProvider;
    }

    public IProductCategoryApplication ProductCategory => 
        _productCategory ??= ServiceProvider.GetRequiredService<IProductCategoryApplication>();
    private IProductCategoryApplication _productCategory { get; set; }

    public IProductApplication Product 
        => _product ??= ServiceProvider.GetRequiredService<IProductApplication>();
    private IProductApplication? _product { get; set; }

    public IServiceProvider ServiceProvider { get; }
}