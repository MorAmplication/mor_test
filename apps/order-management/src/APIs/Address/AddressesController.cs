using Microsoft.AspNetCore.Mvc;

namespace OrderManagementDotNet.APIs;

[ApiController()]
public class AddressesController : AddressesControllerBase
{
    public AddressesController(IAddressesService service)
        : base(service) { }
}
