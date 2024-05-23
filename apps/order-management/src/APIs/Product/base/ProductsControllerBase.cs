using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProductsControllerBase : ControllerBase
{
    public ProductsControllerBase(IProductsService service) { }

    /// <summary>
    /// Create one Product
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateInput input)
    {
        var product = await _service.CreateProduct(input);

        return CreatedAtAction(nameof(Product), new { id = product.Id }, product);
    }

    /// <summary>
    /// Delete one Product
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task DeleteProduct([FromRoute()] ProductIdDto idDto)
    {
        try
        {
            await _service.DeleteProduct(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Products
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<ProductDto>>> Products([FromQuery()] ProductFindMany filter)
    {
        return Ok(await _service.Products(filter));
    }

    /// <summary>
    /// Get one Product
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ProductDto>> Product([FromRoute()] ProductIdDto idDto)
    {
        try
        {
            return await _service.Product(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple Orders records to Product
    /// </summary>
    [HttpPost("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task ConnectOrders(
        [FromRoute()] ProductIdDto idDto,
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
    /// Disconnect multiple Orders records from Product
    /// </summary>
    [HttpDelete("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task DisconnectOrders(
        [FromRoute()] ProductIdDto idDto,
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
    /// Find multiple Orders records for Product
    /// </summary>
    [HttpGet("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task<List<OrderDto>> FindOrders(
        [FromRoute()] ProductIdDto idDto,
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
    /// Update multiple Orders records for Product
    /// </summary>
    [HttpPatch("{Id}/orders")]
    [Authorize(Roles = "user")]
    public async Task UpdateOrders(
        [FromRoute()] ProductIdDto idDto,
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
    /// Update one Product
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task UpdateProduct(
        [FromRoute()] ProductIdDto idDto,
        [FromQuery()] ProductUpdateInput ProductUpdateDto
    )
    {
        try
        {
            await _service.UpdateProduct(idDto, productUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
