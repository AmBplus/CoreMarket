using System.Linq.Expressions;
using Ardalis.Specification;
using Mapster;
using MapsterMapper;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Persistence.Repository;

public class ProductCategoryRepository : BaseGenericRepository<long,ProductCategoryEntity> , IProductCategoryRepository
{
    private readonly ShopManagementContext _contex;
    public ProductCategoryRepository(ShopManagementContext contex) : base(contex)
    {
        _contex = contex;
    }

    public IEnumerable<T> GetAll<T>(ISpecification<ProductCategoryEntity> condation = null) where T : class
    {
        if (condation != null)
        {
            
            return _contex.ProductCategories.ApplySpecification(condation).ProjectToType<T>();
        }
        return _contex.ProductCategories.ProjectToType<T>();
    }

}