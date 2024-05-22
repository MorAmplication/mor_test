using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs.Extensions;

public class AddressesExtensions
{
    public static Address ToModel(this AddressUpdateInput updateDto, AddressIdDto idDto)
    {
        var address = new Address { Id = idDto.Id, Name = updateDto.Name, };
        return address;
    }

    public static AddressDto ToDto(this Address model)
    {
        return new AddressDto
        {
            id = model.id,
            createdAt = model.createdAt,
            updatedAt = model.updatedAt,
            address_1 = model.address_1,
            address_2 = model.address_2,
            city = model.city,
            state = model.state,
            zip = model.zip,
            customers = model.Customers.Select(x => new CustomerIdDto { Id = x.Id }).ToList(),
        };
    }
}
