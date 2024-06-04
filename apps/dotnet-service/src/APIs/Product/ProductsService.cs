using DotnetService.Infrastructure;

namespace DotnetService.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(DotnetServiceDbContext context)
        : base(context) { }
}
