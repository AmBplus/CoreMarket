using System.ComponentModel.DataAnnotations;
using Framework.Shared.Resourses;

namespace ShopManagement.Application.Contract.ProductApplication;



public class CreateProductCmd
{

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string Name { get; set; }
    //-----------------------------------------------------------------------------------------------
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Description))]
    public string? Description { get; set; }

    //-----------------------------------------------------------------------------------------------

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageSrc))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string ImageSrc { get; set; }

    //-----------------------------------------------------------------------------------------------
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageAlt))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string ImageAlt { get; set; }

    //-----------------------------------------------------------------------------------------------
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageTitle))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string ImageTitle { get; set; }

    //-----------------------------------------------------------------------------------------------
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Keywords))]
    public string? Keywords { get; set; }

    //-----------------------------------------------------------------------------------------------
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.MetaDescription))]
    public string? MetaDescription { get; set; }

    //-----------------------------------------------------------------------------------------------
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Slug))]
    public string? Slug { get; set; }
    //-----------------------------------------------------------------------------------------------

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ShortDescription))]
    public string ShortDescription { get;   set; }
    //-----------------------------------------------------------------------------------------------

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Category))]
    [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.NotValidField))]
    public long CategoryId { get;   set; }
    //-----------------------------------------------------------------------------------------------

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.UnitPrice))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.OnlyNumbersAboveZero))]
    public decimal UnitPrice { get;   set; }

}

