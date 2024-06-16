using Microsoft.AspNetCore.Mvc;

namespace Dotnet.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
