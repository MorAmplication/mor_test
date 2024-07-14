using Kkk.APIs;
using Microsoft.AspNetCore.Mvc;

namespace Kkk.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MorsControllerBase : ControllerBase
{
    protected readonly IMorsService _service;

    public MorsControllerBase(IMorsService service)
    {
        _service = service;
    }
}
