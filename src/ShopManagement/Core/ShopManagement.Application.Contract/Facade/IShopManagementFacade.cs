using ShopManagement.Application.Contract.ProductApplication;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ShopManagement.Application.Contract.Facade;

public interface IShopManagementFacade
{
    IProductCategoryApplication ProductCategory { get; }
    IProductApplication Product { get; }
}