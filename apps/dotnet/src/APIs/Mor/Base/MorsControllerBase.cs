using Dotnet.APIs;
using Dotnet.APIs.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MorsControllerBase : ControllerBase
{
    protected readonly IMorsService _service;

    public MorsControllerBase(IMorsService service)
    {
        _service = service;
    }

    [HttpGet("{Id}/create-mor")]
    public async Task<CustomerCustom> CreateMor([FromBody()] string data)
    {
        return await _service.CreateMor(data);
    }
}
