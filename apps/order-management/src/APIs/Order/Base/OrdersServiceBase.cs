using Microsoft.EntityFrameworkCore;
using OrderManagementDotNet.APIs;
using OrderManagementDotNet.APIs.Common;
using OrderManagementDotNet.APIs.Dtos;
using OrderManagementDotNet.APIs.Errors;
using OrderManagementDotNet.APIs.Extensions;
using OrderManagementDotNet.Infrastructure;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs;

public abstract class OrdersServiceBase : IOrdersService
{
    protected readonly OrderManagementDotNetDbContext _context;

    public OrdersServiceBase(OrderManagementDotNetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Orders
    /// </summary>
    public async Task<OrderDto> CreateOrder(OrderCreateInput createDto)
    {
        var order = new Order
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Quantity = createDto.Quantity,
            Discount = createDto.Discount,
            TotalPrice = createDto.TotalPrice
        };

        if (createDto.Id != null)
        {
            order.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            order.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Product != null)
        {
            order.Product = await _context
                .Products.Where(product => createDto.Product.Id == product.Id)
                .FirstOrDefaultAsync();
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Order>(order.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Orders
    /// </summary>
    public async Task DeleteOrder(OrderIdDto idDto)
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
    public async Task<List<OrderDto>> Orders(OrderFindMany findManyArgs)
    {
        var orders = await _context
            .Orders.Include(x => x.Customer)
            .Include(x => x.Product)
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
    public async Task<OrderDto> Order(OrderIdDto idDto)
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
    /// Get a Customer record for Orders
    /// </summary>
    public async Task<CustomerDto> GetCustomer(OrderIdDto idDto)
    {
        var order = await _context
            .Orders.Where(order => order.Id == idDto.Id)
            .Include(order => order.Customer)
            .FirstOrDefaultAsync();
        if (order == null)
        {
            throw new NotFoundException();
        }
        return order.Customer.ToDto();
    }

    /// <summary>
    /// Get a Product record for Orders
    /// </summary>
    public async Task<ProductDto> GetProduct(OrderIdDto idDto)
    {
        var order = await _context
            .Orders.Where(order => order.Id == idDto.Id)
            .Include(order => order.Product)
            .FirstOrDefaultAsync();
        if (order == null)
        {
            throw new NotFoundException();
        }
        return order.Product.ToDto();
    }

    /// <summary>
    /// Update one Orders
    /// </summary>
    public async Task UpdateOrder(OrderIdDto idDto, OrderUpdateInput updateDto)
    {
        var order = updateDto.ToModel(idDto);

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Orders.Any(e => e.Id == order.Id))
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
