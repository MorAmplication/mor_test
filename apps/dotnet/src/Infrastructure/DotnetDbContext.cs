using Dotnet.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Infrastructure;

public class DotnetDbContext : IdentityDbContext<IdentityUser>
{
    public DotnetDbContext(DbContextOptions<DotnetDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}
