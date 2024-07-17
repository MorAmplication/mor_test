using DotnetService.Infrastructure;

namespace DotnetService.APIs;

public class MorsService : MorsServiceBase
{
    public MorsService(DotnetServiceDbContext context)
        : base(context) { }
}
