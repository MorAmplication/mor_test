namespace OrderManagementDotNet.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(ProductsServiceContext context)
        : base(context) { }
}
