using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs;

[ApiController()]
public class ProductsController : ProductsControllerBase
{
    public ProductsController(IProductsService service)
        : base(service) { }
}
