using Framework.Utilities.ResultUtil;

namespace ShopManagement.Application.Contract.ProductCategoryApplication;

public interface IProductCategoryApplication
{
    Task<ResultOperation> Create(CreateProductCategory command, CancellationToken cancellationToken = default);
    Task<ResultOperation> Edit(UpdateProductCategory command, CancellationToken cancellationToken = default);
    Task<ResultOperation<UpdateProductCategory>> GetDetail(long id, CancellationToken cancellationToken = default);
    Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(ProductCategorySearchModel searchModel, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectListProductCategoryViewModel>> SelectList( CancellationToken cancellationToken = default);
}