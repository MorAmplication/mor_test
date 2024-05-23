using OrderManagementDotNet.APIs.Dtos;

namespace OrderManagementDotNet.APIs;

public abstract class AddressesServiceBase : IAddressesService
{
    public AddressesServiceBase(AddressesServiceContext context) { }

    /// <summary>
    /// Connect multiple Customers records to Address
    /// </summary>
    public async Task ConnectCustomers(AddressIdDto idDto, CustomerIdDto[] customersId)
    {
        var address = await _context
            .Addresses.Include(x => x.Customers)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (address == null)
        {
            throw new NotFoundException();
        }

        var customers = await _context
            .Customers.Where(t => customersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (customers.Count == 0)
        {
            throw new NotFoundException();
        }

        var newcustomers = customers.Except(address.customers);
        address.customers.AddRange(newcustomers);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Customers records from Address
    /// </summary>
    public async Task DisconnectCustomers(AddressIdDto idDto, CustomerIdDto[] customersId)
    {
        var address = await _context
            .Addresses.Include(x => x.Customers)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);

        if (address == null)
        {
            throw new NotFoundException();
        }

        var customers = await _context
            .Customers.Where(t => customersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var customer in customers)
        {
            address.Customers.Remove(customer);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Customers records for Address
    /// </summary>
    public async Task<List<CustomerDto>> FindCustomers(
        AddressIdDto idDto,
        CustomerFindMany CustomerFindMany
    )
    {
        var customers = await _context
            .Customers.Where(a => a.Addresses.Any(customer => customer.Id == idDto.Id))
            .ApplyWhere(customerFindMany.Where)
            .ApplySkip(customerFindMany.Skip)
            .ApplyTake(customerFindMany.Take)
            .ApplyOrderBy(customerFindMany.SortBy)
            .ToListAsync();

        return customers.Select(x => x.ToDto());
    }

    /// <summary>
    /// Update multiple Customers records for Address
    /// </summary>
    public async Task UpdateCustomers(AddressIdDto idDto, CustomerIdDto[] customersId)
    {
        var address = await _context
            .Addresses.Include(t => t.Customers)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);

        if (address == null)
        {
            throw new NotFoundException();
        }

        var customers = await _context
            .Customers.Where(a => customerIdDtos.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (customers.Count == 0)
        {
            throw new NotFoundException();
        }

        address.Customers = customers;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Create one Address
    /// </summary>
    public async Task<AddressDto> CreateAddress(AddressCreateInput inputDto)
    {
        var model = new Address { Name = createDto.Name, };
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

        _context.Addresses.Add(model);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Address>(model.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Address
    /// </summary>
    public async Task DeleteAddress(AddressIdDto inputDto)
    {
        var address = await _context.Addresses.FindAsync(idDto.Id);
        if (address == null)
        {
            throw new NotFoundException();
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Addresses
    /// </summary>
    public async Task<List<AddressDto>> Addresses(AddressFindMany findManyArgs)
    {
        var addresses = await _context
            .Addresses.Include(x => x.Customers)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();

        return addresses.ConvertAll(address => address.ToDto());
    }

    /// <summary>
    /// Get one Address
    /// </summary>
    public async Task<AddressDto> Address(AddressIdDto idDto)
    {
        var addresses = await this.Addresses(
            new AddressFindMany { Where = new AddressWhereInput { Id = idDto.Id } }
        );
        var address = addresses.FirstOrDefault();
        if (address == null)
        {
            throw new NotFoundException();
        }

        return address;
    }

    /// <summary>
    /// Update one Address
    /// </summary>
    public async Task UpdateAddress(AddressUpdateInput updateDto)
    {
        var address = updateDto.ToModel(idDto);

        if (updateDto.CustomerIds != null)
        {
            address.Customers = await _context
                .Customers.Where(customer =>
                    updateDto.CustomerIds.Select(t => t.Id).Contains(customer.Id)
                )
                .ToListAsync();
        }

        _context.Entry(address).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddressExists(idDto))
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
