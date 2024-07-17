using DotnetService.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.Infrastructure;

public class DotnetServiceDbContext : IdentityDbContext<IdentityUser>
{
    public DotnetServiceDbContext(DbContextOptions<DotnetServiceDbContext> options)
        : base(options) { }

    public DbSet<MorDbModel> Mors { get; set; }

    public DbSet<VikaDbModel> Vikas { get; set; }
}
