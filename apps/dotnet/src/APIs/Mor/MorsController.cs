using Dotnet.APIs;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.APIs;

[ApiController()]
public class MorsController : MorsControllerBase
{
    public MorsController(IMorsService service)
        : base(service) { }
}
