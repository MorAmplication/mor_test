namespace OrderManagementDotNet.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(CustomersServiceContext context)
        : base(context) { }
}
