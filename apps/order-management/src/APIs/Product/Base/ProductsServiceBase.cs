using Microsoft.EntityFrameworkCore;
using OrderManagementDotNet.APIs;
using OrderManagementDotNet.APIs.Common;
using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.APIs.Errors;
using OrderManagementDotNet.APIs.Extensions;
using OrderManagementDotNet.Infrastructure;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs;

public abstract class ProductsServiceBase : IProductsService
{
    protected readonly OrderManagementDotNetDbContext _context;

    public ProductsServiceBase(OrderManagementDotNetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Product
    /// </summary>
    public async Task<ProductDto> CreateProduct(ProductCreateInput createDto)
    {
        var product = new Product
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Name = createDto.Name,
            ItemPrice = createDto.ItemPrice,
            Description = createDto.Description
        };

        if (createDto.Id != null)
        {
            product.Id = createDto.Id;
        }
        if (createDto.Orders != null)
        {
            product.Orders = await _context
                .Orders.Where(order => createDto.Orders.Select(t => t.Id).Contains(order.Id))
                .ToListAsync();
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Product>(product.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Product
    /// </summary>
    public async Task DeleteProduct(ProductIdDto idDto)
    {
        var product = await _context.Products.FindAsync(idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Products
    /// </summary>
    public async Task<List<ProductDto>> Products(ProductFindMany findManyArgs)
    {
        var products = await _context
            .Products.Include(x => x.Orders)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return products.ConvertAll(product => product.ToDto());
    }

    /// <summary>
    /// Get one Product
    /// </summary>
    public async Task<ProductDto> Product(ProductIdDto idDto)
    {
        var products = await this.Products(
            new ProductFindMany { Where = new ProductWhereInput { Id = idDto.Id } }
        );
        var product = products.FirstOrDefault();
        if (product == null)
        {
            throw new NotFoundException();
        }

        return product;
    }

    /// <summary>
    /// Connect multiple Orders records to Product
    /// </summary>
    public async Task ConnectOrders(ProductIdDto idDto, OrderIdDto[] ordersId)
    {
        var product = await _context
            .Products.Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        var orders = await _context
            .Orders.Where(t => ordersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (orders.Count == 0)
        {
            throw new NotFoundException();
        }

        var ordersToConnect = orders.Except(product.Orders);

        foreach (var order in ordersToConnect)
        {
            product.Orders.Add(order);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Orders records from Product
    /// </summary>
    public async Task DisconnectOrders(ProductIdDto idDto, OrderIdDto[] ordersId)
    {
        var product = await _context
            .Products.Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        var orders = await _context
            .Orders.Where(t => ordersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var order in orders)
        {
            product.Orders?.Remove(order);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Orders records for Product
    /// </summary>
    public async Task<List<OrderDto>> FindOrders(ProductIdDto idDto, OrderFindMany productFindMany)
    {
        var orders = await _context
            .Orders.Where(m => m.ProductId == idDto.Id)
            .ApplyWhere(productFindMany.Where)
            .ApplySkip(productFindMany.Skip)
            .ApplyTake(productFindMany.Take)
            .ApplyOrderBy(productFindMany.SortBy)
            .ToListAsync();

        return orders.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Orders records for Product
    /// </summary>
    public async Task UpdateOrders(ProductIdDto idDto, OrderIdDto[] ordersId)
    {
        var product = await _context
            .Products.Include(t => t.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        var orders = await _context
            .Orders.Where(a => ordersId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (orders.Count == 0)
        {
            throw new NotFoundException();
        }

        product.Orders = orders;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one Product
    /// </summary>
    public async Task UpdateProduct(ProductIdDto idDto, ProductUpdateInput updateDto)
    {
        var product = updateDto.ToModel(idDto);

        if (updateDto.Orders != null)
        {
            product.Orders = await _context
                .Orders.Where(order => updateDto.Orders.Select(t => t.Id).Contains(order.Id))
                .ToListAsync();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(e => e.Id == product.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
