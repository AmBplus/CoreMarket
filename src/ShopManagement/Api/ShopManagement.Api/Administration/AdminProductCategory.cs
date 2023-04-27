//using System.Text.Json;
//using Framework.Shared.Resourses;
//using Framework.Utilities;
//using Framework.Utilities.ResultUtil;
//using Microsoft.AspNetCore.Mvc;
//using ShopManagement.Application.Contract.ProductCategoryApplication;

//namespace ShopManagement.Api.administration;
//[Route("Api/administration/ProductCategory/[action]")]
//public class AdminProductCategory : ControllerBase
//{
//    private readonly IProductCategoryApplication _productCategoryApplication;

//    public AdminProductCategory(IProductCategoryApplication productCategoryApplication)
//    {
//        this._productCategoryApplication = productCategoryApplication;
//    }

//    [HttpPost("Create")]
//    public async Task<IActionResult> Create(CreateProductCategory productCategoryCmd)
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
