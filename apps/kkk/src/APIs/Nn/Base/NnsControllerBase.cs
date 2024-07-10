using Kkk.APIs;
using Kkk.APIs.Common;
using Kkk.APIs.Dtos;
using Kkk.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kkk.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class NnsControllerBase : ControllerBase
{
    protected readonly INnsService _service;

    public NnsControllerBase(INnsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one nn
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Nn>> CreateNn(NnCreateInput input)
    {
        var nn = await _service.CreateNn(input);

        return CreatedAtAction(nameof(Nn), new { id = nn.Id }, nn);
    }

    /// <summary>
    /// Delete one nn
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteNn([FromRoute()] NnWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteNn(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many nns
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Nn>>> Nns([FromQuery()] NnFindManyArgs filter)
    {
        return Ok(await _service.Nns(filter));
    }

    /// <summary>
    /// Get one nn
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Nn>> Nn([FromRoute()] NnWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Nn(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about nn records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> NnsMeta([FromQuery()] NnFindManyArgs filter)
    {
        return Ok(await _service.NnsMeta(filter));
    }

    /// <summary>
    /// Update one nn
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateNn(
        [FromRoute()] NnWhereUniqueInput uniqueId,
        [FromQuery()] NnUpdateInput nnUpdateDto
    )
    {
        try
        {
            await _service.UpdateNn(uniqueId, nnUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
