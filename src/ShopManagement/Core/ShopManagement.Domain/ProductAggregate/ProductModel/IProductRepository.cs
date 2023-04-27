using Framework.Domain.Repository;

namespace ShopManagement.Domain.ProductAggregate.ProductModel;

public interface IProductRepository : IBaseGenericRepository<long,ProductEntity>
{
    
}