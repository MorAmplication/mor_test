using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public abstract class CustomersServiceBase : ICustomersService
{
    public CustomersServiceBase(CustomersServiceContext context) { }

    /// <summary>
    /// Create one Customer
    /// </summary>
    public async Task<CustomerDto> createCustomer(CustomerCreateInput inputDto)
    {
        var model = new Customer { Name = createDto.Name, };
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

        if (createDto.AddressIds != null)
        {
            model.Addresses = await _context
                .Addresses.Where(address =>
                    createDto.AddressIds.Select(t => t.Id).Contains(address.Id)
                )
                .ToListAsync();
        }

        _context.Customers.Add(model);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Customer>(model.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Connect multiple Orders records to Customer
    /// </summary>
    public async Task connectOrders(CustomerIdDTO idDto, OrderIdDTO OrderId)
    {
        var customer = await _context
            .Customers.Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (customer == null)
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

        var neworders = orders.Except(customer.orders);
        customer.orders.AddRange(neworders);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Orders records from Customer
    /// </summary>
    public async Task disconnectOrders(CustomerIdDTO idDto, OrderIdDTO OrderId)
    {
        var customer = await _context
            .Customers.Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);

        if (customer == null)
        {
            throw new NotFoundException();
        }

        var orders = await _context
            .Orders.Where(t => ordersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var order in orders)
        {
            customer.Orders.Remove(order);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Orders records for Customer
    /// </summary>
    public async Task<List<OrderDto>> findOrders(CustomerIdDTO idDto, OrderFindMany OrderFindMany)
    {
        var customer = await _context.customers.FirstAsync(x => x.Id == idDto.Id);

        if (customer == null)
        {
            throw new NotFoundException();
        }

        return customer.Orders.Select(order => order.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Orders records for Customer
    /// </summary>
    public async Task updateOrders(CustomerIdDTO idDto, OrderIdDTO OrderId)
    {
        var customer = await _context
            .Customers.Include(t => t.Orders)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);

        if (customer == null)
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

        customer.Orders = orders;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete one Customer
    /// </summary>
    public async Task deleteCustomer(CustomerIdDTO inputDto)
    {
        var customer = await _context.Customers.FindAsync(idDto.Id);
        if (customer == null)
        {
            throw new NotFoundException();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Customers
    /// </summary>
    public async Task<List<CustomerDto>> customers(CustomerFindMany findManyArgs)
    {
        var customers = await _context
            .Customers.Include(x => x.Orders)
            .Include(x => x.Addresses)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();

        return customers.ConvertAll(customer => customer.ToDto());
    }

    /// <summary>
    /// Get one Customer
    /// </summary>
    public async Task<CustomerDto> customer(CustomerIdDTO idDto)
    {
        var customers = await this.Customers(
            new CustomerFindMany { Where = new CustomerWhereInput { Id = idDto.Id } }
        );
        var customer = customers.FirstOrDefault();
        if (customer == null)
        {
            throw new NotFoundException();
        }

        return customer;
    }

    /// <summary>
    /// Update one Customer
    /// </summary>
    public async Task updateCustomer(CustomerUpdateInput updateDto)
    {
        var customer = updateDto.ToModel(idDto);

        if (updateDto.OrderIds != null)
        {
            customer.Orders = await _context
                .Orders.Where(order => updateDto.OrderIds.Select(t => t.Id).Contains(order.Id))
                .ToListAsync();
        }

        if (updateDto.AddressIds != null)
        {
            customer.Addresses = await _context
                .Addresses.Where(address =>
                    updateDto.AddressIds.Select(t => t.Id).Contains(address.Id)
                )
                .ToListAsync();
        }

        _context.Entry(customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(idDto))
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
