using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public interface IAddressesService
{
    /// <summary>
    /// Connect multiple Customers records to Address
    /// </summary>
    public Task ConnectCustomers(AddressIdDto idDto, CustomerIdDto[] customersId);

    /// <summary>
    /// Disconnect multiple Customers records from Address
    /// </summary>
    public Task DisconnectCustomers(AddressIdDto idDto, CustomerIdDto[] customersId);

    /// <summary>
    /// Find multiple Customers records for Address
    /// </summary>
    public Task<List<CustomerDto>> FindCustomers(
        AddressIdDto idDto,
        CustomerFindMany CustomerFindMany
    );

    /// <summary>
    /// Update multiple Customers records for Address
    /// </summary>
    public Task UpdateCustomers(AddressIdDto idDto, CustomerIdDto[] customersId);

    /// <summary>
    /// Create one Address
    /// </summary>
    public Task<AddressDto> CreateAddress(AddressCreateInput addressDto);

    /// <summary>
    /// Delete one Address
    /// </summary>
    public Task DeleteAddress(AddressIdDto idDto);

    /// <summary>
    /// Find many Addresses
    /// </summary>
    public Task<List<AddressDto>> Addresses(AddressFindMany findManyArgs);

    /// <summary>
    /// Get one Address
    /// </summary>
    public Task<AddressDto> Address(AddressIdDto idDto);

    /// <summary>
    /// Update one Address
    /// </summary>
    public Task UpdateAddress(AddressIdDto idDto, AddressUpdateInput updateDto);
}
