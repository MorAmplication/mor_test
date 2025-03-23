using Microsoft.AspNetCore.Mvc;

namespace OrderManagementDotNet.APIs;

[ApiController()]
public class ProductsController : ProductsControllerBase
{
    public ProductsController(IProductsService service)
        : base(service) { }
}
