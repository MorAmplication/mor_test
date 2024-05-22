using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs.Extensions;

public class ProductsExtensions
{
    public static Product ToModel(this ProductUpdateInput updateDto, ProductIdDto idDto)
    {
        var product = new Product { Id = idDto.Id, Name = updateDto.Name, };
        return product;
    }

    public static ProductDto ToDto(this Product model)
    {
        return new ProductDto
        {
            id = model.id,
            createdAt = model.createdAt,
            updatedAt = model.updatedAt,
            name = model.name,
            itemPrice = model.itemPrice,
            description = model.description,
            orders = model.Orders.Select(x => new OrderIdDto { Id = x.Id }).ToList(),
        };
    }
}
