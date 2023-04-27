using Ardalis.Specification;
using ShopManagement.Domain.ProductAggregate.ProductModel;

namespace ShopManagement.Application.Contract.ProductApplication.ProductSpecification;

public class ProductSearchCondationSpec : Specification<ProductEntity>
{
    public ProductSearchCondationSpec(ProductSearchCmd productSearchCmd)
    {
        if (string.IsNullOrWhiteSpace(productSearchCmd.Name))
        {
            Query.Where(x => x.Name.Contains(productSearchCmd.Name));
        }

        if (productSearchCmd.CategoryId != 0)
        {
            Query.Where(x => x.CategoryId == productSearchCmd.CategoryId);
        }

        if ( string.IsNullOrWhiteSpace(productSearchCmd.Code))
        {
            Query.Where(x => x.Code.Contains(productSearchCmd.Code));
        }
        
    }
}