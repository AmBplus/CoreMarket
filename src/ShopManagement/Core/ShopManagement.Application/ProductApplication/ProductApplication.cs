using Mapster;
using ShopManagement.Application.Contract.Maping;
using ShopManagement.Application.Contract.ProductApplication;
using ShopManagement.Application.Contract.ProductApplication.ProductSpecification;
using ShopManagement.Application.Contract.Sm.UnitOfWork;
using ShopManagement.Domain.ProductAggregate.ProductModel;

namespace ShopManagement.Application.ProductApplication;

public class ProductApplication : IProductApplication
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWorkShopManagement _unitOfWork;

    public ProductApplication(IProductRepository repository, IUnitOfWorkShopManagement unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    

    public async Task<ResultOperation> Create(CreateProductCmd command, CancellationToken cancellationToken = default)
    {
        // validate 
       
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

    public async Task<ResultOperation> Edit(UpdateProductCmd command, CancellationToken cancellationToken = default)
    {
       
        var result = command.GetValidationResults();
        if (result.Count > 0)
        {
            return result.GetFailedResultWithError_s();
        }
        var entity = await _repository.Get(x => x.Id == command.Id);
        if (entity == null)
        {
            return ResultOperation.BuildFailedResult(EntityName.Product.NotFind());
        }
        await _repository.Update(command.MapToProductCategory());
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation> SetInStock(long id , CancellationToken cancellationToken = default)
    {
        var entity = await _repository.Get(x => x.Id == id,track:true);
        if (entity == null)
        {
            return ResultOperation.BuildFailedResult(EntityName.Product.NotFind());
        }
        entity.InStock();
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation> SetNotInStock(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.Get(x => x.Id == id, track: true);
        if (entity == null)
        {
            return ResultOperation.BuildFailedResult(EntityName.Product.NotFind());
        }
        entity.OutOfStock();
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation<ProductDetails>> GetDetail(long id , CancellationToken cancellationToken = default)
    {
        ProductDetails details = new ProductDetails();
        var entity = await _repository.Get(x => x.Id == id);
        if (entity == null) return details.ToFailed("انتیتی یافت نشد ");
        details = entity.Adapt<ProductDetails>();
        return details.ToSuccessResult();
  
    }

    public async Task<ResultOperation<IEnumerable<ProductViewModel>>> Search(ProductSearchCmd searchModel , CancellationToken cancellationToken = default)
    {
        var spec = new ProductSearchCondationSpec(searchModel);
        var result = await _repository.GetAll(spec);
        if (result == null)
        {
            return ResultOperation<IEnumerable<ProductViewModel>>.BuildFailedResult("لیست خالیست");
        }
        return result.ProjectToType<ProductEntity, ProductViewModel>().ToSuccessResult();
    
    }
}