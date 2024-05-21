namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AddressesControllerBase : ControllerBase
{
    public AddressesControllerBase(IAddressesService service) { }
}
