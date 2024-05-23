using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CustomersControllerBase : ControllerBase
{
    public CustomersControllerBase(ICustomersService service) { }

    /// <summary>
    /// Create one Customer
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerCreateInput input)
    {
        var customer = await _service.CreateCustomer(input);

        return CreatedAtAction(nameof(Customer), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Connect multiple Orders records to Customer
    /// </summary>
    [HttpPost("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task ConnectOrders(
        [FromRoute()] CustomerIdDto idDto,
        [FromQuery()] OrderIdDto[] ordersId
    )
    {
        try
        {
            await _service.ConnectOrders(idDto, orderIds);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Orders records from Customer
    /// </summary>
    [HttpDelete("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task DisconnectOrders(
        [FromRoute()] CustomerIdDto idDto,
        [FromBody()] OrderIdDto[] ordersId
    )
    {
        try
        {
            await _service.DisconnectOrders(idDto, orderIds);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Orders records for Customer
    /// </summary>
    [HttpGet("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task<List<OrderDto>> FindOrders(
        [FromRoute()] CustomerIdDto idDto,
        [FromQuery()] OrderFindMany filter
    )
    {
        try
        {
            return Ok(await _service.FindOrders(idDto, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Address record for Customer
    /// </summary>
    [HttpGet("{Id}/addresses")]
    [Authorize(Roles = "user")]
    public async Task<List<AddressDto>> GetAddress([FromRoute()] CustomerIdDto idDto)
    {
        var address = await _service.GetAddress(idDto);
        return Ok(address);
    }

    /// <summary>
    /// Update multiple Orders records for Customer
    /// </summary>
    [HttpPatch("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task UpdateOrders(
        [FromRoute()] CustomerIdDto idDto,
        [FromBody()] OrderIdDto[] ordersId
    )
    {
        try
        {
            await _service.UpdateOrders(idDto, orderIds);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Delete one Customer
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task DeleteCustomer([FromRoute()] CustomerIdDto idDto)
    {
        try
        {
            await _service.DeleteCustomer(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Customers
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<CustomerDto>>> Customers(
        [FromQuery()] CustomerFindMany filter
    )
    {
        return Ok(await _service.Customers(filter));
    }

    /// <summary>
    /// Get one Customer
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<CustomerDto>> Customer([FromRoute()] CustomerIdDto idDto)
    {
        try
        {
            return await _service.Customer(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Customer
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task UpdateCustomer(
        [FromRoute()] CustomerIdDto idDto,
        [FromQuery()] CustomerUpdateInput CustomerUpdateDto
    )
    {
        try
        {
            await _service.UpdateCustomer(idDto, customerUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
