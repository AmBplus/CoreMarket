namespace ShopManagement.Application.Contract.ProductApplication;

public class ProductDetails
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageSrc { get; private set; }
    public string ImageAlt { get; private set; }
    public string ImageTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }

}