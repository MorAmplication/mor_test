using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public abstract class OrdersServiceBase : IOrdersService
{
    public OrdersServiceBase(OrdersServiceContext context) { }

    /// <summary>
    /// Create one Orders
    /// </summary>
    public async Task<OrderDto> createOrder(OrderCreateInput inputDto)
    {
        var model = new Order { Name = createDto.Name, };
        if (createDto.Id != null)
        {
            model.Id = createDto.Id.Value;
        }

        if (createDto.CustomerIds != null)
        {
            model.Customers = await _context
                .Customers.Where(customer =>
                    createDto.CustomerIds.Select(t => t.Id).Contains(customer.Id)
                )
                .ToListAsync();
        }

        if (createDto.ProductIds != null)
        {
            model.Products = await _context
                .Products.Where(product =>
                    createDto.ProductIds.Select(t => t.Id).Contains(product.Id)
                )
                .ToListAsync();
        }

        _context.Orders.Add(model);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Order>(model.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Orders
    /// </summary>
    public async Task deleteOrder(OrderIdDTO inputDto)
    {
        var order = await _context.Orders.FindAsync(idDto.Id);
        if (order == null)
        {
            throw new NotFoundException();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    public async Task<List<OrderDto>> orders(OrderFindMany findManyArgs)
    {
        var orders = await _context
            .Orders.Include(x => x.Customers)
            .Include(x => x.Products)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();

        return orders.ConvertAll(order => order.ToDto());
    }

    /// <summary>
    /// Get one Orders
    /// </summary>
    public async Task<OrderDto> order(OrderIdDTO idDto)
    {
        var orders = await this.Orders(
            new OrderFindMany { Where = new OrderWhereInput { Id = idDto.Id } }
        );
        var order = orders.FirstOrDefault();
        if (order == null)
        {
            throw new NotFoundException();
        }

        return order;
    }

    /// <summary>
    /// Update one Orders
    /// </summary>
    public async Task updateOrder(OrderUpdateInput updateDto)
    {
        var order = updateDto.ToModel(idDto);

        if (updateDto.CustomerIds != null)
        {
            order.Customers = await _context
                .Customers.Where(customer =>
                    updateDto.CustomerIds.Select(t => t.Id).Contains(customer.Id)
                )
                .ToListAsync();
        }

        if (updateDto.ProductIds != null)
        {
            order.Products = await _context
                .Products.Where(product =>
                    updateDto.ProductIds.Select(t => t.Id).Contains(product.Id)
                )
                .ToListAsync();
        }

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(idDto))
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