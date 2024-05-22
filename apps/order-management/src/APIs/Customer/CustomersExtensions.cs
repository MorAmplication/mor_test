using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs.Extensions;

public class CustomersExtensions
{
    public static Customer ToModel(this CustomerUpdateInput updateDto, CustomerIdDto idDto)
    {
        var customer = new Customer { Id = idDto.Id, Name = updateDto.Name, };
        return customer;
    }

    public static CustomerDto ToDto(this Customer model)
    {
        return new CustomerDto
        {
            id = model.id,
            createdAt = model.createdAt,
            updatedAt = model.updatedAt,
            firstName = model.firstName,
            lastName = model.lastName,
            email = model.email,
            phone = model.phone,
            orders = model.Orders.Select(x => new OrderIdDto { Id = x.Id }).ToList(),
            address = new AddressIdDto { Id = model.WorkspaceId },
        };
    }
}
