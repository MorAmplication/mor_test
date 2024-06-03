using OrderManagementDotNet.APIs;

namespace OrderManagementDotNet;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IAddressesService, AddressesService>();
        services.AddScoped<IProductsService, ProductsService>();
    }
}
