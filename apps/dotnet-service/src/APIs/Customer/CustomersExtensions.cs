using DotnetService.APIs.Dtos;
using DotnetService.Infrastructure.Models;

namespace DotnetService.APIs.Extensions;

public static class CustomersExtensions
{
    public static CustomerDto ToDto(this Customer model)
    {
        return new CustomerDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Orders = model.Orders.Select(x => new OrderIdDto { Id = x.Id }).ToList(),
        };
    }

    public static Customer ToModel(this CustomerUpdateInput updateDto, CustomerIdDto idDto)
    {
        var customer = new Customer { Id = idDto.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            customer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            customer.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return customer;
    }
}
