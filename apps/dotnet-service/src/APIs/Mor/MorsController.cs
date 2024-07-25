using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs;

[ApiController()]
public class MorsController : MorsControllerBase
{
    public MorsController(IMorsService service)
        : base(service) { }
}
