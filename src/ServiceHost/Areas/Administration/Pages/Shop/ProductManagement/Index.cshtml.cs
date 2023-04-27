using Base.AspCoreUtility.Infrastructure;
using Base.Resourses;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApplication;
using ShopManagement.Application.Contract.ProductCategoryApplication;
using System.Threading;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductManagement
{
    public class IndexModel : BasePageModel
    {
        public readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductApplication productCategoryApplication, IProductCategoryApplication productCategoryApplication1)
        {
            _productApplication = productCategoryApplication;
            _productCategoryApplication = productCategoryApplication1;
        }
        public ProductSearchCmd SearchModel { get; set; }
        public UpdateProductCategory UpdateProductCategoryCmd { get; set; }
        [ViewData]
        public SelectList ProductCategoriesSelectList { get; set; }
        public IEnumerable<ProductViewModel> ViewResult { get; set; }
        public async Task OnGet(ProductSearchCmd searchModel, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _productApplication.Search(searchModel);
                ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                    "Name");
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    ViewResult = new List<ProductViewModel>();
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
        public async Task<IActionResult> OnGetEdit(long id , CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _productApplication.GetDetail(id);
                ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                    "Name"); 
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
        public async Task<IActionResult> OnPostEdit(UpdateProductCmd updateProductCategory , CancellationToken cancellationToken = default)
        {
            try
            {
                var result =  await _productApplication.Edit(updateProductCategory);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                        "Name");
                    return BadRequest(result);
                }
                AddRangeToastSuccess(result.Message);
                return new OkObjectResult(result); ;
            }
            catch (Exception e)
            {
                ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                    "Name");
                return new OkObjectResult(ErrorMessages.ProblemOccurred); 
            }
        }
        public async Task<IActionResult> OnGetCreate(CancellationToken cancellationToken = default)
        {
            ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                "Name");
            return Partial("./Create");
        }
        public async Task<IActionResult> OnPostCreate(CreateProductCmd productCategoryCmd, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Partial("./Create",productCategoryCmd);
                }
                var result = await _productApplication.Create(productCategoryCmd);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                        "Name");
                    return BadRequest(result);
                }

                AddRangeToastSuccess(result.Message);
                return new OkObjectResult(result); ;
            }
            catch (Exception e)
            {
                ProductCategoriesSelectList = new SelectList((await _productCategoryApplication.SelectList(cancellationToken)), "Id",
                    "Name");
                return new OkObjectResult(ErrorMessages.ProblemOccurred);
            }
        }
    }
}
