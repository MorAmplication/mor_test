using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Orders
    /// </summary>
    public Task<OrderDto> CreateOrder(OrderCreateInput orderDto);

    /// <summary>
    /// Delete one Orders
    /// </summary>
    public Task DeleteOrder(OrderIdDto idDto);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<OrderDto>> Orders(OrderFindMany findManyArgs);

    /// <summary>
    /// Get one Orders
    /// </summary>
    public Task<OrderDto> Order(OrderIdDto idDto);

    /// <summary>
    /// Get a Customer record for Orders
    /// </summary>
    public Task<CustomerDto> GetCustomer(OrderIdDto idDto);

    /// <summary>
    /// Get a Product record for Orders
    /// </summary>
    public Task<ProductDto> GetProduct(OrderIdDto idDto);

    /// <summary>
    /// Update one Orders
    /// </summary>
    public Task UpdateOrder(OrderIdDto idDto, OrderUpdateInput updateDto);
}
