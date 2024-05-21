namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProductsControllerBase : ControllerBase
{
    public ProductsControllerBase(IProductsService service) { }
}
