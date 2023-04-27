using Framework.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAggregate.ProductModel;

namespace ShopManagement.Persistence.Repository;

public class ProductRepository : BaseGenericRepository<long,ProductEntity> , IProductRepository
{
    private readonly ShopManagementContext _contex;
    public ProductRepository(ShopManagementContext contex) : base(contex)
    {
        _contex = contex;
    }
}