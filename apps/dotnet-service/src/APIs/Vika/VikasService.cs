using DotnetService.Infrastructure;

namespace DotnetService.APIs;

public class VikasService : VikasServiceBase
{
    public VikasService(DotnetServiceDbContext context)
        : base(context) { }
}
