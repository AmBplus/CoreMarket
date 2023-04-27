using Framework.Shared.Resourses;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace ShopManagement.Application.Contract.ProductCategoryApplication;

public class SelectListProductCategoryViewModel
{
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Id))]
    public long Id { get; set; }
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    public string Name { get; set; }
}