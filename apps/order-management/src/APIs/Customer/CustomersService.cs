using OrderManagementDotNet.Infrastructure;

namespace OrderManagementDotNet.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(OrderManagementDotNetDbContext context)
        : base(context) { }
}
