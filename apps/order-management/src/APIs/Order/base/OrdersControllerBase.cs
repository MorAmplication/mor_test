using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrdersControllerBase : ControllerBase
{
    public OrdersControllerBase(IOrdersService service) { }

    /// <summary>
    /// Create one Orders
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<OrderDto>> CreateOrder(OrderCreateInput input)
    {
        var order = await _service.CreateOrder(input);

        return CreatedAtAction(nameof(Order), new { id = order.Id }, order);
    }

    /// <summary>
    /// Delete one Orders
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task DeleteOrder([FromRoute()] OrderIdDto idDto)
    {
        try
        {
            await _service.DeleteOrder(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<OrderDto>>> Orders([FromQuery()] OrderFindMany filter)
    {
        return Ok(await _service.Orders(filter));
    }

    /// <summary>
    /// Get one Orders
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<OrderDto>> Order([FromRoute()] OrderIdDto idDto)
    {
        try
        {
            return await _service.Order(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Customer record for Orders
    /// </summary>
    [HttpGet("{Id}/customers")]
    [Authorize(Roles = "user")]
    public async Task<List<CustomerDto>> GetCustomer([FromRoute()] OrderIdDto idDto)
    {
        var customer = await _service.GetCustomer(idDto);
        return Ok(customer);
    }

    /// <summary>
    /// Get a Product record for Orders
    /// </summary>
    [HttpGet("{Id}/products")]
    [Authorize(Roles = "user")]
    public async Task<List<ProductDto>> GetProduct([FromRoute()] OrderIdDto idDto)
    {
        var product = await _service.GetProduct(idDto);
        return Ok(product);
    }

    /// <summary>
    /// Update one Orders
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task UpdateOrder(
        [FromRoute()] OrderIdDto idDto,
        [FromQuery()] OrderUpdateInput OrderUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrder(idDto, orderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
