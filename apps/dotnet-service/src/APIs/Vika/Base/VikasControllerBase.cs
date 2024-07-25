using DotnetService.APIs;
using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;
using DotnetService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VikasControllerBase : ControllerBase
{
    protected readonly IVikasService _service;

    public VikasControllerBase(IVikasService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Vika
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Vika>> CreateVika(VikaCreateInput input)
    {
        var vika = await _service.CreateVika(input);

        return CreatedAtAction(nameof(Vika), new { id = vika.Id }, vika);
    }

    /// <summary>
    /// Delete one Vika
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVika([FromRoute()] VikaWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVika(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Vikas
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Vika>>> Vikas([FromQuery()] VikaFindManyArgs filter)
    {
        return Ok(await _service.Vikas(filter));
    }

    /// <summary>
    /// Get one Vika
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Vika>> Vika([FromRoute()] VikaWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Vika(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Vika
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVika(
        [FromRoute()] VikaWhereUniqueInput uniqueId,
        [FromQuery()] VikaUpdateInput vikaUpdateDto
    )
    {
        try
        {
            await _service.UpdateVika(uniqueId, vikaUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Mors records to Vika
    /// </summary>
    [HttpPost("{Id}/mors")]
    public async Task<ActionResult> ConnectMors(
        [FromRoute()] VikaWhereUniqueInput uniqueId,
        [FromQuery()] MorWhereUniqueInput[] morsId
    )
    {
        try
        {
            await _service.ConnectMors(uniqueId, morsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Mors records from Vika
    /// </summary>
    [HttpDelete("{Id}/mors")]
    public async Task<ActionResult> DisconnectMors(
        [FromRoute()] VikaWhereUniqueInput uniqueId,
        [FromBody()] MorWhereUniqueInput[] morsId
    )
    {
        try
        {
            await _service.DisconnectMors(uniqueId, morsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Mors records for Vika
    /// </summary>
    [HttpGet("{Id}/mors")]
    public async Task<ActionResult<List<Mor>>> FindMors(
        [FromRoute()] VikaWhereUniqueInput uniqueId,
        [FromQuery()] MorFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindMors(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Vika records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VikasMeta([FromQuery()] VikaFindManyArgs filter)
    {
        return Ok(await _service.VikasMeta(filter));
    }

    /// <summary>
    /// Update multiple Mors records for Vika
    /// </summary>
    [HttpPatch("{Id}/mors")]
    public async Task<ActionResult> UpdateMors(
        [FromRoute()] VikaWhereUniqueInput uniqueId,
        [FromBody()] MorWhereUniqueInput[] morsId
    )
    {
        try
        {
            await _service.UpdateMors(uniqueId, morsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
