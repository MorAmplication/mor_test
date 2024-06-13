using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs.Extensions;

public static class ProductsExtensions
{
    public static ProductDto ToDto(this Product model)
    {
        return new ProductDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Name = model.Name,
            ItemPrice = model.ItemPrice,
            Description = model.Description,
            Orders = model.Orders?.Select(x => new OrderIdDto { Id = x.Id }).ToList(),
        };
    }

    public static Product ToModel(this ProductUpdateInput updateDto, ProductIdDto idDto)
    {
        var product = new Product
        {
            Id = idDto.Id,
            Name = updateDto.Name,
            ItemPrice = updateDto.ItemPrice,
            Description = updateDto.Description
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            product.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            product.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return product;
    }
}
