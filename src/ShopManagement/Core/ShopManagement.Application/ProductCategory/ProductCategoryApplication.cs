using System.Data;
using Mapster;
using ShopManagement.Application.Contract.Sm.UnitOfWork;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using Microsoft.Data.SqlClient;
using ShopManagement.Application.Contract.Maping;
using ShopManagement.Application.Contract.ProductCategoryApplication;
using Base.Shared.ResultUtil;
using Base.Shared;
using Base.Application.Extensions;

namespace ShopManagement.Application.ProductCategory;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository _repository;
    private readonly IUnitOfWorkShopManagement _unitOfWork;

    public ProductCategoryApplication(IProductCategoryRepository repository, IUnitOfWorkShopManagement unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultOperation> Create(CreateProductCategory command , CancellationToken cancellationToke = default)
    {
        var result = command.GetValidationResults();
        if (result.Count > 0)
        {
            var errors = result.Select(x => x.ErrorMessage);
            return ResultOperation.BuildFailedResult(errors!);
        }
        await _repository.Create(command.MapToProductCategory());
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation> Edit(UpdateProductCategory command ,CancellationToken cancellationToken = default)
    {
        var result = command.GetValidationResults();
        if (result.Count > 0)
        {
            return result.GetFailedResultWithError_s();
        }
        var entity = await _repository.Get(x => x.Id == command.Id,true);
        if (entity == null) return ResultOperation.BuildFailedResult("دسته بندی محصول خواسته شده پیدا نشد");
      
        await _repository.Update(command.MapToProductCategory(entity));
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation<UpdateProductCategory>> GetDetail(long id, CancellationToken cancellationToken = default)
    {   
        UpdateProductCategory details = new UpdateProductCategory();
        var entity = await _repository.Get(x => x.Id == id);
        if (entity == null) return details.ToFailed("انتیتی یافت نشد ");
        details = entity.Adapt<UpdateProductCategory>();
        return details.ToSuccessResult();
    }

    public async Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(
        ProductCategorySearchModel searchModel, CancellationToken cancellationToken = default)
    {
        
        // Generate Query 
        string query = @$"select * from ProductCategories pc 
        where 1 = 1
        {(string.IsNullOrWhiteSpace(searchModel?.Name) ? "":$"And pc.Name LIKE @{nameof(searchModel.Name)}" )}" ;

        var sqlParamerter = new SqlParameter[]
        {
            new SqlParameter()
            {
                ParameterName = $"@{nameof(searchModel.Name)}",
                Value = $"%{searchModel.Name}%",
            },
        };
        // Get Result 

        var result = await _repository.GetAll(query,sqlParamerter);
        if (result == null)
            return ResultOperation<IEnumerable<ProductCategoryViewModel>>.BuildFailedResult("لیست خالیست");

        return result.ProjectToType<ProductCategoryEntity, ProductCategoryViewModel>().ToSuccessResult();
    }

    public async Task<IEnumerable<SelectListProductCategoryViewModel>> SelectList( CancellationToken cancellationToken = default)
    {
        return _repository.GetAll<SelectListProductCategoryViewModel>();
    }
}