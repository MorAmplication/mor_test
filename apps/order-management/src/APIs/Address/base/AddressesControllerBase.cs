using Microsoft.AspNetCore.Mvc;
using OrderManagementDotNet.APIs;
using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.APIs.Errors;

namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AddressesControllerBase : ControllerBase
{
    protected readonly IAddressesService _service;

    public AddressesControllerBase(IAddressesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Connect multiple Customers records to Address
    /// </summary>
    [HttpPost("{Id}/customers")]
    public async Task<ActionResult> ConnectCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromQuery()] CustomerIdDto[] customersId
    )
    {
        try
        {
            await _service.ConnectCustomers(idDto, customersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Customers records from Address
    /// </summary>
    [HttpDelete("{Id}/customers")]
    public async Task<ActionResult> DisconnectCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromBody()] CustomerIdDto[] customersId
    )
    {
        try
        {
            await _service.DisconnectCustomers(idDto, customersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Customers records for Address
    /// </summary>
    [HttpGet("{Id}/customers")]
    public async Task<ActionResult<List<CustomerDto>>> FindCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromQuery()] CustomerFindMany filter
    )
    {
        try
        {
            return Ok(await _service.FindCustomers(idDto, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Customers records for Address
    /// </summary>
    [HttpPatch("{Id}/customers")]
    public async Task<ActionResult> UpdateCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromBody()] CustomerIdDto[] customersId
    )
    {
        try
        {
            await _service.UpdateCustomers(idDto, customersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Create one Address
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<AddressDto>> CreateAddress(AddressCreateInput input)
    {
        var address = await _service.CreateAddress(input);

        return CreatedAtAction(nameof(Address), new { id = address.Id }, address);
    }

    /// <summary>
    /// Delete one Address
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAddress([FromRoute()] AddressIdDto idDto)
    {
        try
        {
            await _service.DeleteAddress(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Addresses
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<AddressDto>>> Addresses(
        [FromQuery()] AddressFindMany filter
    )
    {
        return Ok(await _service.Addresses(filter));
    }

    /// <summary>
    /// Get one Address
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<AddressDto>> Address([FromRoute()] AddressIdDto idDto)
    {
        try
        {
            return await _service.Address(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Address
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAddress(
        [FromRoute()] AddressIdDto idDto,
        [FromQuery()] AddressUpdateInput addressUpdateDto
    )
    {
        try
        {
            await _service.UpdateAddress(idDto, addressUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
