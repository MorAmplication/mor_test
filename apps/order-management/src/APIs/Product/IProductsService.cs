using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public interface IProductsService
{
    /// <summary>
    /// Create one Product
    /// </summary>
    public Task<ProductDto> CreateProduct(ProductCreateInput productDto);

    /// <summary>
    /// Delete one Product
    /// </summary>
    public Task DeleteProduct(ProductIdDto idDto);

    /// <summary>
    /// Find many Products
    /// </summary>
    public Task<List<ProductDto>> Products(ProductFindMany findManyArgs);

    /// <summary>
    /// Get one Product
    /// </summary>
    public Task<ProductDto> Product(ProductIdDto idDto);

    /// <summary>
    /// Connect multiple Orders records to Product
    /// </summary>
    public Task ConnectOrders(ProductIdDto idDto, OrderIdDto[] ordersId);

    /// <summary>
    /// Disconnect multiple Orders records from Product
    /// </summary>
    public Task DisconnectOrders(ProductIdDto idDto, OrderIdDto[] ordersId);

    /// <summary>
    /// Find multiple Orders records for Product
    /// </summary>
    public Task<List<OrderDto>> FindOrders(ProductIdDto idDto, OrderFindMany OrderFindMany);

    /// <summary>
    /// Update multiple Orders records for Product
    /// </summary>
    public Task UpdateOrders(ProductIdDto idDto, OrderIdDto[] ordersId);

    /// <summary>
    /// Update one Product
    /// </summary>
    public Task UpdateProduct(ProductIdDto idDto, ProductUpdateInput updateDto);
}
