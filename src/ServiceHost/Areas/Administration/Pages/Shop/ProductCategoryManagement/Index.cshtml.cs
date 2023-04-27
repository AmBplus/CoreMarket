using Framework.Asp.Infrastructure;
using Framework.Shared.Resourses;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.Facade;
using ShopManagement.Application.Contract.ProductCategoryApplication;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategoryManagement
{
    public class IndexModel : BasePageModel
    {
        public readonly IShopManagementFacade _ShopManagement;

        public IndexModel(IShopManagementFacade shopManagementFacade)
        {
            _ShopManagement = shopManagementFacade;
        }
        public ProductCategorySearchModel SearchModel { get; set; }
        public UpdateProductCategory UpdateProductCategoryCmd { get; set; }
       
        public IEnumerable<ProductCategoryViewModel> ViewResult { get; set; }
        public async Task OnGet(ProductCategorySearchModel searchModel)
        {
            try
            {
                var result = await _ShopManagement.ProductCategory.Search(searchModel);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    ViewResult = new List<ProductCategoryViewModel>();
                    return;
                }
                ViewResult = result.Data;
            }
            catch (Exception e)
            {
                AddToastError(ErrorMessages.ProblemOccurred);
            }
        }
        [Route("id")]
        public async Task<IActionResult> OnGetEdit(long id)
        {
            try
            {
                var result = await _ShopManagement.ProductCategory.GetDetail(id);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    return Page();
                }

                var resutlMapToEditCmd = result.Data.Adapt<UpdateProductCategory>();
                return Partial("./Edit", resutlMapToEditCmd);
            }
            catch (Exception e)
            {
                AddToastError(ErrorMessages.ProblemOccurred);
                return Page();
            }
        }
        public async Task<IActionResult> OnPostEdit(UpdateProductCategory  updateProductCategory)
        {
            try
            {
                var result =  await _ShopManagement.ProductCategory.Edit(updateProductCategory);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    return BadRequest(result);
                }
                AddRangeToastSuccess(result.Message);
                return new JsonResult(result); ;
            }
            catch (Exception e)
            {
                return BadRequest(ErrorMessages.ProblemOccurred); 
            }
        }
        public async Task<IActionResult> OnGetCreate()
        {
            return Partial("./Create");
        }

        public async Task<JsonResult> OnPostCreate(CreateProductCategory createProductCategory)
        {
            var result = await  _ShopManagement.ProductCategory.Create(createProductCategory);
            return new JsonResult(result);
        }
      
    }
}
