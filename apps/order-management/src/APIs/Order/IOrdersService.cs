using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs.Dtos;

public interface IOrdersService
{
    /// <summary>
    /// Create one Orders
    /// </summary>
    public Task<OrderDto> CreateOrder(OrderCreateInput orderDto) { }

    /// <summary>
    /// Delete one Orders
    /// </summary>
    public Task DeleteOrder(OrderIdDto idDto) { }

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<OrderDto>> Orders(OrderFindMany findManyArgs) { }

    /// <summary>
    /// Get one Orders
    /// </summary>
    public Task Order(OrderIdDto idDto) { }

    /// <summary>
    /// Update one Orders
    /// </summary>
    public Task UpdateOrder(OrderUpdateInput updateInput) { }
}
