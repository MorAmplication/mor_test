using OrderManagementDotNet.Infrastructure;

namespace OrderManagementDotNet.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(OrderManagementDotNetDbContext context)
        : base(context) { }
}
