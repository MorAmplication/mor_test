using DotnetService.Infrastructure;

namespace DotnetService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(DotnetServiceDbContext context)
        : base(context) { }
}
