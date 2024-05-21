namespace OrderManagementDotNet.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(OrdersServiceContext context)
        : base(context) { }
}
