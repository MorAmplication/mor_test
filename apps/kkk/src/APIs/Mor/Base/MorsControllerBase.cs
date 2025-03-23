using Kkk.APIs;
using Kkk.APIs.Dtos;
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

    [HttpGet("{Id}/mor-test")]
    public async Task<string> MorTest([FromBody()] Nn nnDto)
    {
        return await _service.MorTest(nnDto);
    }
}
