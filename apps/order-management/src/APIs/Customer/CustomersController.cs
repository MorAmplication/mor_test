using Microsoft.AspNetCore.Mvc;

namespace OrderManagementDotNet.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
