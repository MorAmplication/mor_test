using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs.Dtos;

public interface ICustomersService
{
    /// <summary>
    /// Create one Customer
    /// </summary>
    public Task<CustomerDto> CreateCustomer(CustomerCreateInput customerDto) { }

    /// <summary>
    /// Connect multiple Orders records to Customer
    /// </summary>
    public Task connectOrders(CustomerIdDto idDto, CustomerIdDto[] CustomersId) { }

    /// <summary>
    /// Disconnect multiple Orders records from Customer
    /// </summary>
    public Task disconnectOrders(CustomerIdDto idDto, CustomerIdDto[] CustomersId) { }

    /// <summary>
    /// Find multiple Orders records for Customer
    /// </summary>
    public Task<List<OrderDto>> findOrders(CustomerIdDto idDto, OrderFindMany OrderFindMany) { }

    /// <summary>
    /// Update multiple Orders records for Customer
    /// </summary>
    public Task updateOrders(CustomerIdDto idDto, CustomerIdDto[] CustomersId) { }

    /// <summary>
    /// Delete one Customer
    /// </summary>
    public Task DeleteCustomer(CustomerIdDto idDto) { }

    /// <summary>
    /// Find many Customers
    /// </summary>
    public Task<List<CustomerDto>> Customers(CustomerFindMany findManyArgs) { }

    /// <summary>
    /// Get one Customer
    /// </summary>
    public Task Customer(CustomerIdDto idDto) { }

    /// <summary>
    /// Update one Customer
    /// </summary>
    public Task UpdateCustomer(CustomerUpdateInput updateInput) { }
}
