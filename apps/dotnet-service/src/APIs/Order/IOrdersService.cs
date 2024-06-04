using DotnetService.APIs.Dtos;

namespace DotnetService.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Order
    /// </summary>
    public Task<OrderDto> CreateOrder(OrderCreateInput orderDto);

    /// <summary>
    /// Delete one Order
    /// </summary>
    public Task DeleteOrder(OrderIdDto idDto);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<OrderDto>> Orders(OrderFindMany findManyArgs);

    /// <summary>
    /// Get one Order
    /// </summary>
    public Task<OrderDto> Order(OrderIdDto idDto);

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public Task<CustomerDto> GetCustomer(OrderIdDto idDto);

    /// <summary>
    /// Update one Order
    /// </summary>
    public Task UpdateOrder(OrderIdDto idDto, OrderUpdateInput updateDto);
}
