using DotnetService.APIs;
using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;
using DotnetService.APIs.Errors;
using DotnetService.APIs.Extensions;
using DotnetService.Infrastructure;
using DotnetService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.APIs;

public abstract class AddressesServiceBase : IAddressesService
{
    protected readonly DotnetServiceDbContext _context;

    public AddressesServiceBase(DotnetServiceDbContext context)
    {
        _context = context;
    }

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

        var customersToConnect = customers.Except(address.Customers);

        foreach (var customer in customersToConnect)
        {
            address.Customers.Add(customer);
        }

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
            address.Customers?.Remove(customer);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Customers records for Address
    /// </summary>
    public async Task<List<CustomerDto>> FindCustomers(
        AddressIdDto idDto,
        CustomerFindMany addressFindMany
    )
    {
        var customers = await _context
            .Customers.Where(m => m.AddressId == idDto.Id)
            .ApplyWhere(addressFindMany.Where)
            .ApplySkip(addressFindMany.Skip)
            .ApplyTake(addressFindMany.Take)
            .ApplyOrderBy(addressFindMany.SortBy)
            .ToListAsync();

        return customers.Select(x => x.ToDto()).ToList();
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
            .Customers.Where(a => customersId.Select(x => x.Id).Contains(a.Id))
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
    public async Task<AddressDto> CreateAddress(AddressCreateInput createDto)
    {
        var address = new Address
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Address_1 = createDto.Address_1,
            Address_2 = createDto.Address_2,
            City = createDto.City,
            State = createDto.State,
            Zip = createDto.Zip
        };

        if (createDto.Id != null)
        {
            address.Id = createDto.Id;
        }
        if (createDto.Customers != null)
        {
            address.Customers = await _context
                .Customers.Where(customer =>
                    createDto.Customers.Select(t => t.Id).Contains(customer.Id)
                )
                .ToListAsync();
        }

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Address>(address.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Address
    /// </summary>
    public async Task DeleteAddress(AddressIdDto idDto)
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
    public async Task UpdateAddress(AddressIdDto idDto, AddressUpdateInput updateDto)
    {
        var address = updateDto.ToModel(idDto);

        if (updateDto.Customers != null)
        {
            address.Customers = await _context
                .Customers.Where(customer =>
                    updateDto.Customers.Select(t => t.Id).Contains(customer.Id)
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
            if (!_context.Addresses.Any(e => e.Id == address.Id))
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
