using OrderManagementDotNet.Infrastructure;

namespace OrderManagementDotNet.APIs;

public class AddressesService : AddressesServiceBase
{
    public AddressesService(OrderManagementDotNetDbContext context)
        : base(context) { }
}
