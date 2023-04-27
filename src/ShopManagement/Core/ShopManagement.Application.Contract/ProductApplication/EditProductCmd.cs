namespace ShopManagement.Application.Contract.ProductApplication
{
    public class EditProductCmd : CreateProductCmd
    {
        public long Id { get; set; }
    }
}
