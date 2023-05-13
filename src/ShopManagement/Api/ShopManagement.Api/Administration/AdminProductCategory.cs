using System.Text.Json;
using Base.Resourses;
using Base.Shared;
using Base.Shared.ResultUtil;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Facade;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ShopManagement.Api.administration;
//[Route("Api/administration/ProductCategory/[action]")]
//public class AdminProductCategory : ControllerBase
//{
//    private readonly IProductCategoryApplication _productCategoryApplication;

//    public AdminProductCategory(IProductCategoryApplication productCategoryApplication)
//    {
//        this._productCategoryApplication = productCategoryApplication;
//    }

//    [HttpPost("Create")]
//    public async Task<IActionResult> Create(CreateProductCategoryDTO productCategoryCmd)
//    {
//        try
//        {
//            if (!productCategoryCmd.IsValid())
//            {
//                var errors = productCategoryCmd.GetValidationResults().Select(x=>x.ErrorMessage);
//                return BadRequest(ResultOperation.BuildFailedResult(errors));
//            }
//            var result = await _productCategoryApplication.Create(productCategoryCmd);
//            if (result.IsSuccess == false)
//            {

//                return Ok(result);
//            }

//            return BadRequest(result);
//        }
//        catch (Exception e)
//        {
//            return BadRequest(ErrorMessages.ProblemOccurred);
//        }
//    }
//}
// [Route("https://localhost:7203/api/[Controller]/[Action]")]
// [ApiController]
// public class AdminProductCategoryController : ControllerBase
// {
//     private IShopManagementFacade _ShopManagement { get; set; }
//
//     public AdminProductCategoryController(IShopManagementFacade shopManagement)
//     {
//         _ShopManagement = shopManagement;
//     }
//     [HttpGet]
//     public async Task<IActionResult> Index(CancellationToken can = default)
//     {
//         
//         var resutl = await _ShopManagement.ProductCategory.Search(new ProductCategorySearchModelDTO() { Name = null });
//         return Ok();
//     }
// }