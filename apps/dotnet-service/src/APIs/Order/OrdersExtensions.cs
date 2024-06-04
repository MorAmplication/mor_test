using DotnetService.APIs.Dtos;
using DotnetService.Infrastructure.Models;

namespace DotnetService.APIs.Extensions;

public static class OrdersExtensions
{
    public static OrderDto ToDto(this Order model)
    {
        return new OrderDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Quantity = model.Quantity,
            Discount = model.Discount,
            TotalPrice = model.TotalPrice,
            Customer = new CustomerIdDto { Id = model.CustomerId },
            Product = new ProductIdDto { Id = model.ProductId },
        };
    }

    public static Order ToModel(this OrderUpdateInput updateDto, OrderIdDto idDto)
    {
        var order = new Order
        {
            Id = idDto.Id,
            Quantity = updateDto.Quantity,
            Discount = updateDto.Discount,
            TotalPrice = updateDto.TotalPrice
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            order.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            order.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return order;
    }
}
