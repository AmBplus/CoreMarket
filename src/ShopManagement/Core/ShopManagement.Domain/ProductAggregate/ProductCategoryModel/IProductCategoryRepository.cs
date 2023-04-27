using System.Linq.Expressions;
using Ardalis.Specification;
using Base.Domain.Repository;

namespace ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

public interface IProductCategoryRepository : IBaseGenericRepository<long,ProductCategoryEntity>
{
    public IEnumerable<T> GetAll<T>(ISpecification<ProductCategoryEntity> condation = null) where T : class;
}