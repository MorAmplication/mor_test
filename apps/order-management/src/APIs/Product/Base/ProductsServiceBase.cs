using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public abstract class ProductsServiceBase : IProductsService
{
    public ProductsServiceBase(ProductsServiceContext context) { }

    /// <summary>
    /// Create one Product
    /// </summary>
    public async Task<ProductDto> createProduct(ProductCreateInput inputDto)
    {
        var model = new Product { Name = createDto.Name, };
        if (createDto.Id != null)
        {
            model.Id = createDto.Id.Value;
        }

        if (createDto.OrderIds != null)
        {
            model.Orders = await _context
                .Orders.Where(order => createDto.OrderIds.Select(t => t.Id).Contains(order.Id))
                .ToListAsync();
        }

        _context.Products.Add(model);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Product>(model.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Product
    /// </summary>
    public async Task deleteProduct(ProductIdDTO inputDto)
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
    public async Task<List<ProductDto>> products(ProductFindMany findManyArgs)
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
    public async Task<ProductDto> product(ProductIdDTO idDto)
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
    public async Task connectOrders(ProductIdDTO idDto, OrderIdDTO OrderId)
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

        var neworders = orders.Except(product.orders);
        product.orders.AddRange(neworders);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Orders records from Product
    /// </summary>
    public async Task disconnectOrders(ProductIdDTO idDto, OrderIdDTO OrderId)
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
            product.Orders.Remove(order);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Orders records for Product
    /// </summary>
    public async Task<List<OrderDto>> findOrders(ProductIdDTO idDto, OrderFindMany OrderFindMany)
    {
        var orders = await _context
            .Orders.Where(a => a.Products.Any(order => order.Id == idDto.Id))
            .ApplyWhere(orderFindMany.Where)
            .ApplySkip(orderFindMany.Skip)
            .ApplyTake(orderFindMany.Take)
            .ApplyOrderBy(orderFindMany.SortBy)
            .ToListAsync();

        return orders.Select(x => x.ToDto());
    }

    /// <summary>
    /// Update multiple Orders records for Product
    /// </summary>
    public async Task updateOrders(ProductIdDTO idDto, OrderIdDTO OrderId)
    {
        var product = await _context
            .Products.Include(t => t.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);

        if (product == null)
        {
            throw new NotFoundException();
        }

        var orders = await _context
            .Orders.Where(a => orderIdDtos.Select(x => x.Id).Contains(a.Id))
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
    public async Task updateProduct(ProductUpdateInput updateDto)
    {
        var product = updateDto.ToModel(idDto);

        if (updateDto.OrderIds != null)
        {
            product.Orders = await _context
                .Orders.Where(order => updateDto.OrderIds.Select(t => t.Id).Contains(order.Id))
                .ToListAsync();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(idDto))
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
