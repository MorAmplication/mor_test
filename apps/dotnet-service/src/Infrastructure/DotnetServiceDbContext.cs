using DotnetService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.Infrastructure;

public class DotnetServiceDbContext : DbContext
{
    public DotnetServiceDbContext(DbContextOptions<DotnetServiceDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }
}
