
namespace ShopManagement.Application.Contract.ProductApplication;

public interface IProductApplication
{
    Task<ResultOperation> Create(CreateProductCmd command, CancellationToken cancellationToken = default);
    Task<ResultOperation> Edit(UpdateProductCmd command, CancellationToken cancellationToken = default);
    Task<ResultOperation> SetInStock(long id, CancellationToken cancellationToken = default);
    Task<ResultOperation> SetNotInStock(long id, CancellationToken cancellationToken = default);
    Task<ResultOperation<ProductDetails>> GetDetail(long id, CancellationToken cancellationToken = default);
    Task<ResultOperation<IEnumerable<ProductViewModel>>> Search(ProductSearchCmd searchModel, CancellationToken cancellationToken = default);
}