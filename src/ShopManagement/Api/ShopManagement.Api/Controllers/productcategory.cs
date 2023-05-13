using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Facade;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ShopManagement.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class productcategoryController : ControllerBase
{
    private IShopManagementFacade _ShopManagement { get; set; }

    public productcategoryController(IShopManagementFacade shopManagement)
    {
        _ShopManagement = shopManagement;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var resutl = await _ShopManagement.ProductCategory.Search(new ProductCategorySearchModelDTO() { Name = null });

        return Ok();
    }
}