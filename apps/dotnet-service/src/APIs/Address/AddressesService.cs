using DotnetService.Infrastructure;

namespace DotnetService.APIs;

public class AddressesService : AddressesServiceBase
{
    public AddressesService(DotnetServiceDbContext context)
        : base(context) { }
}
