using OrderManagementDotNet.APIs;

namespace OrderManagementDotNet;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAddressesService, AddressesService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IProductsService, ProductsService>();
    }
}
