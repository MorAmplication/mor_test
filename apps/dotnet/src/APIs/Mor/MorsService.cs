using Dotnet.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.APIs;

public class MorsService : MorsServiceBase
{
    public MorsService(DotnetDbContext context)
        : base(context) { }
}
