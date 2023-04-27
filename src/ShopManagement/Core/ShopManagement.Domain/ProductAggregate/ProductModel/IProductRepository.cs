
using Base.Domain.Repository;

namespace ShopManagement.Domain.ProductAggregate.ProductModel;

public interface IProductRepository : IBaseGenericRepository<long,ProductEntity>
{
    
}