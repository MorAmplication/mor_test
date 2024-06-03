using Microsoft.AspNetCore.Mvc;

namespace OrderManagementDotNet.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
