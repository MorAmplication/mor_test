using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs.Extensions;

public class OrdersExtensions
{
    public static Order ToModel(this OrderUpdateInput updateDto, OrderIdDto idDto)
    {
        var order = new Order { Id = idDto.Id, Name = updateDto.Name, };
        return order;
    }

    public static OrderDto ToDto(this Order model)
    {
        return new OrderDto
        {
            id = model.id,
            createdAt = model.createdAt,
            updatedAt = model.updatedAt,
            quantity = model.quantity,
            discount = model.discount,
            totalPrice = model.totalPrice,
            customer = new CustomerIdDto { Id = model.WorkspaceId },
            product = new ProductIdDto { Id = model.WorkspaceId },
        };
    }
}
