using DotnetService.APIs.Dtos;
using DotnetService.Infrastructure.Models;

namespace DotnetService.APIs.Extensions;

public static class AddressesExtensions
{
    public static AddressDto ToDto(this Address model)
    {
        return new AddressDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Address_1 = model.Address_1,
            Address_2 = model.Address_2,
            City = model.City,
            State = model.State,
            Zip = model.Zip,
            Customers = model.Customers.Select(x => new CustomerIdDto { Id = x.Id }).ToList(),
        };
    }

    public static Address ToModel(this AddressUpdateInput updateDto, AddressIdDto idDto)
    {
        var address = new Address
        {
            Id = idDto.Id,
            Address_1 = updateDto.Address_1,
            Address_2 = updateDto.Address_2,
            City = updateDto.City,
            State = updateDto.State,
            Zip = updateDto.Zip
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            address.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            address.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return address;
    }
}
