using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs;

[ApiController()]
public class VikasController : VikasControllerBase
{
    public VikasController(IVikasService service)
        : base(service) { }
}
