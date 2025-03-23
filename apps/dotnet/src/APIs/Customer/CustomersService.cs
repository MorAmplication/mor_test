using Dotnet.Infrastructure;

namespace Dotnet.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(DotnetDbContext context)
        : base(context) { }
}
