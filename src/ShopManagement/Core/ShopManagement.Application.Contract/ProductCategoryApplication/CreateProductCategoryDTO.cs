using Base.Resourses;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductCategoryApplication;



public class CreateProductCategoryDTO
{
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string Name { get; set; }
    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Description))]
    public string? Description { get; set; }

    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageSrc))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string ImageSrc { get; set; }

    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageAlt))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string ImageAlt { get; set; }

    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.ImageTitle))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string ImageTitle { get; set; }

    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Keywords))]
    public string? Keywords { get; set; }

    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.MetaDescription))]
    public string? MetaDescription { get; set; }

    //***********************************************************************************************
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Slug))]
    public string? Slug { get; set; }


}

