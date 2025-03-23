using OrderManagementDotNet.Infrastructure;

namespace OrderManagementDotNet.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(OrderManagementDotNetDbContext context)
        : base(context) { }
}
