using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Domain.ProductAggregate.ProductModel;

public class ProductEntity : BaseEntity<long>
{
    public ProductEntity(string name, string slug, string keywords
        , string imageSrc, string imageAlt
        , string imageTitle, string description,
        string metaDescription, string shortDescription
        , long categoryId, decimal unitPrice)
    {
        Name = name;
        Slug = slug;
        Keywords = keywords;
        ImageSrc = imageSrc;
        ImageAlt = imageAlt;
        ImageTitle = imageTitle;
        Description = description;
        MetaDescription = metaDescription;
        ShortDescription = shortDescription;
        CategoryId = categoryId;
        UnitPrice = unitPrice;
    }
    public void Edit(string name, string slug, string keywords
        , string imageSrc, string imageAlt
        , string imageTitle, string description,
        string metaDescription, string shortDescription
        , long categoryId, decimal unitPrice)
    {
        Name = name;
        Slug = slug;
        Keywords = keywords;
        ImageSrc = imageSrc;
        ImageAlt = imageAlt;
        ImageTitle = imageTitle;
        Description = description;
        MetaDescription = metaDescription;
        ShortDescription = shortDescription;
        CategoryId = categoryId;
        UnitPrice = unitPrice;
    }

    public string Name { get; private set; }
    public string? Code { get;private set; }  
    public string? Slug { get; private set; }
    public string? Keywords { get; private set; }
    public string ImageSrc { get; private set; }
    public string ImageAlt { get; private set; }
    public string ImageTitle { get; private set; }
    public string? Description { get; private set; }
    public string? MetaDescription { get; private set; }
    public string? ShortDescription { get; private set; }
    public virtual ProductCategoryEntity Category { get; private set; }
    public long CategoryId { get; private set; }
    public bool IsInStock { get; private set; }
    public decimal UnitPrice { get; private set; }
    
    public void InStock()
    {
        IsInStock = true;
    }
    public void OutOfStock()
    {
        IsInStock = false;
    }
}