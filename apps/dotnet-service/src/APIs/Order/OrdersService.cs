using DotnetService.Infrastructure;

namespace DotnetService.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(DotnetServiceDbContext context)
        : base(context) { }
}
