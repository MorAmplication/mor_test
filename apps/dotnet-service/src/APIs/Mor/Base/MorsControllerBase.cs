using DotnetService.APIs;
using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;
using DotnetService.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MorsControllerBase : ControllerBase
{
    protected readonly IMorsService _service;

    public MorsControllerBase(IMorsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Mor
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Mor>> CreateMor(MorCreateInput input)
    {
        var mor = await _service.CreateMor(input);

        return CreatedAtAction(nameof(Mor), new { id = mor.Id }, mor);
    }

    /// <summary>
    /// Delete one Mor
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteMor([FromRoute()] MorWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMor(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Mors
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Mor>>> Mors([FromQuery()] MorFindManyArgs filter)
    {
        return Ok(await _service.Mors(filter));
    }

    /// <summary>
    /// Get one Mor
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Mor>> Mor([FromRoute()] MorWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Mor(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Mor records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MorsMeta([FromQuery()] MorFindManyArgs filter)
    {
        return Ok(await _service.MorsMeta(filter));
    }

    /// <summary>
    /// Update one Mor
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateMor(
        [FromRoute()] MorWhereUniqueInput uniqueId,
        [FromQuery()] MorUpdateInput morUpdateDto
    )
    {
        try
        {
            await _service.UpdateMor(uniqueId, morUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
