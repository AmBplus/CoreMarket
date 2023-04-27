using ShopManagement.Domain.ProductAggregate.ProductModel;

namespace ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

public class ProductCategoryEntity : BaseEntity<long>
{
    private ProductCategoryEntity() { }
    public ProductCategoryEntity(string name, string description, string imageSrc, string imageAlt, string imageTitle, string keywords, string metaDescription, string slug)
    {
        Name = name;
        Description = description;
        ImageSrc = imageSrc;
        ImageAlt = imageAlt;
        ImageTitle = imageTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
    }

    public void Edit(string name, string description, string imageSrc, string imageAlt, string imageTitle, string keywords, string metaDescription, string slug)
    {
        Name = name;
        Description = description;
        ImageSrc = imageSrc;
        ImageAlt = imageAlt;
        ImageTitle = imageTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
    }

    #region Properties

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string ImageSrc { get; private set; }
    public string ImageAlt { get; private set; }
    public string ImageTitle { get; private set; }
    public string? Keywords { get; private set; }
    public string? MetaDescription { get; private set; }
    public string Slug { get; private set; }
    public virtual ICollection<ProductEntity>  ProductEntities { get; private set; }
    #endregion /Properties
}