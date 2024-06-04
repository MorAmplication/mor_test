using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs;

[ApiController()]
public class AddressesController : AddressesControllerBase
{
    public AddressesController(IAddressesService service)
        : base(service) { }
}
