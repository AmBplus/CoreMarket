using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductCategoryApplication;

public class UpdateProductCategory : CreateProductCategory
{
    [Display(ResourceType = typeof(PropertiesName),Name = nameof(PropertiesName.Id))]
    [Range(minimum:1,maximum:long.MaxValue,ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
    public long Id { get; set; }
}