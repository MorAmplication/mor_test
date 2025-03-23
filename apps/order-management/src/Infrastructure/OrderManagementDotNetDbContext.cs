using Microsoft.EntityFrameworkCore;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.Infrastructure;

public class OrderManagementDotNetDbContext : DbContext
{
    public OrderManagementDotNetDbContext(DbContextOptions<OrderManagementDotNetDbContext> options)
        : base(options) { }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Product> Products { get; set; }
}
