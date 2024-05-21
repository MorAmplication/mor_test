using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs.Dtos;

public interface IProductsService
{
    /// <summary>
    /// Create one Product
    /// </summary>
    public Task<ProductDto> CreateProduct(ProductCreateInput productDto) { }

    /// <summary>
    /// Delete one Product
    /// </summary>
    public Task DeleteProduct(ProductIdDto idDto) { }

    /// <summary>
    /// Find many Products
    /// </summary>
    public Task<List<ProductDto>> Products(ProductFindMany findManyArgs) { }

    /// <summary>
    /// Get one Product
    /// </summary>
    public Task Product(ProductIdDto idDto) { }

    /// <summary>
    /// Connect multiple Orders records to Product
    /// </summary>
    public Task connectOrders(ProductIdDto idDto, ProductIdDto[] ProductsId) { }

    /// <summary>
    /// Disconnect multiple Orders records from Product
    /// </summary>
    public Task disconnectOrders(ProductIdDto idDto, ProductIdDto[] ProductsId) { }

    /// <summary>
    /// Find multiple Orders records for Product
    /// </summary>
    public Task<List<OrderDto>> findOrders(ProductIdDto idDto, OrderFindMany OrderFindMany) { }

    /// <summary>
    /// Update multiple Orders records for Product
    /// </summary>
    public Task updateOrders(ProductIdDto idDto, ProductIdDto[] ProductsId) { }

    /// <summary>
    /// Update one Product
    /// </summary>
    public Task UpdateProduct(ProductUpdateInput updateInput) { }
}
