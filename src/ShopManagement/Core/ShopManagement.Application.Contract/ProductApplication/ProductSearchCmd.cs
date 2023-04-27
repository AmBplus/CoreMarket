namespace ShopManagement.Application.Contract.ProductApplication;

public class ProductSearchCmd
{
    public string Name { get; set; }
    public string Code { get; set; }
    public long CategoryId { get; set; }

}