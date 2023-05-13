
using Base.Shared.ResultUtil;

namespace ShopManagement.Application.Contract.ProductCategoryApplication;

public interface IProductCategoryApplication
{
    Task<ResultOperation> Create(CreateProductCategoryDTO command, CancellationToken cancellationToken = default);
    Task<ResultOperation> Edit(UpdateProductCategoryDto command, CancellationToken cancellationToken = default);
    Task<ResultOperation<UpdateProductCategoryDto>> GetDetail(long id, CancellationToken cancellationToken = default);
    Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(ProductCategorySearchModelDTO searchModelDto, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectListProductCategoryViewModel>> SelectList( CancellationToken cancellationToken = default);
}