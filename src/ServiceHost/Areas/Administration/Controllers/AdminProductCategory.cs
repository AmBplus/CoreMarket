using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ServiceHost.Areas.Administration.Controllers;
[Route("Api/administration/ProductCategory/[action]")]
[ApiController]
public class AdminProductCategory : ControllerBase
{
    private readonly IProductCategoryApplication _productCategoryApplication;

    public AdminProductCategory(IProductCategoryApplication productCategoryApplication)
    {
        this._productCategoryApplication = productCategoryApplication;
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromForm]CreateProductCategory productCategoryCmd)
    {
        try
        {
            if (!productCategoryCmd.IsValid())
            {
                var errors = productCategoryCmd.GetValidationResults().Select(x=>x.ErrorMessage);
                return BadRequest(ResultOperation.BuildFailedResult(errors));
            }
            var result = await _productCategoryApplication.Create(productCategoryCmd);
            if (result.IsSuccess == false)
            {
                
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(ErrorMessages.ProblemOccurred);
        }
    }
}
