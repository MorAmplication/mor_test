using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AddressesControllerBase : ControllerBase
{
    public AddressesControllerBase(IAddressesService service) { }

    /// <summary>
    /// Connect multiple Customers records to Address
    /// </summary>
    [HttpPost("{Id}/customers")]
    [Authorize(Roles = "user")]
    public async Task ConnectCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromQuery()] CustomerIdDto[] customersId
    )
    {
        try
        {
            await _service.ConnectCustomers(idDto, customerIds);
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
    [Authorize(Roles = "user")]
    public async Task DisconnectCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromBody()] CustomerIdDto[] customersId
    )
    {
        try
        {
            await _service.DisconnectCustomers(idDto, customerIds);
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
    [Authorize(Roles = "user")]
    public async Task<List<CustomerDto>> FindCustomers(
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
    [Authorize(Roles = "user")]
    public async Task UpdateCustomers(
        [FromRoute()] AddressIdDto idDto,
        [FromBody()] CustomerIdDto[] customersId
    )
    {
        try
        {
            await _service.UpdateCustomers(idDto, customerIds);
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
    [Authorize(Roles = "user")]
    public async Task<ActionResult<AddressDto>> CreateAddress(AddressCreateInput input)
    {
        var address = await _service.CreateAddress(input);

        return CreatedAtAction(nameof(Address), new { id = address.Id }, address);
    }

    /// <summary>
    /// Delete one Address
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task DeleteAddress([FromRoute()] AddressIdDto idDto)
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
    [Authorize(Roles = "user")]
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
    [Authorize(Roles = "user")]
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
    [Authorize(Roles = "user")]
    public async Task UpdateAddress(
        [FromRoute()] AddressIdDto idDto,
        [FromQuery()] AddressUpdateInput AddressUpdateDto
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
