using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs.Dtos;

public interface IAddressesService
{
    /// <summary>
    /// Connect multiple Customers records to Address
    /// </summary>
    public Task connectCustomers(AddressIdDto idDto, AddressIdDto[] AddressesId) { }

    /// <summary>
    /// Disconnect multiple Customers records from Address
    /// </summary>
    public Task disconnectCustomers(AddressIdDto idDto, AddressIdDto[] AddressesId) { }

    /// <summary>
    /// Find multiple Customers records for Address
    /// </summary>
    public Task<List<CustomerDto>> findCustomers(
        AddressIdDto idDto,
        CustomerFindMany CustomerFindMany
    ) { }

    /// <summary>
    /// Update multiple Customers records for Address
    /// </summary>
    public Task updateCustomers(AddressIdDto idDto, AddressIdDto[] AddressesId) { }

    /// <summary>
    /// Create one Address
    /// </summary>
    public Task<AddressDto> CreateAddress(AddressCreateInput addressDto) { }

    /// <summary>
    /// Delete one Address
    /// </summary>
    public Task DeleteAddress(AddressIdDto idDto) { }

    /// <summary>
    /// Find many Addresses
    /// </summary>
    public Task<List<AddressDto>> Addresses(AddressFindMany findManyArgs) { }

    /// <summary>
    /// Get one Address
    /// </summary>
    public Task Address(AddressIdDto idDto) { }

    /// <summary>
    /// Update one Address
    /// </summary>
    public Task UpdateAddress(AddressUpdateInput updateInput) { }
}
