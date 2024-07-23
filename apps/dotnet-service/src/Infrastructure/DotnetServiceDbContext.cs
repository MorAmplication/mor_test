using DotnetService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.Infrastructure;

public class DotnetServiceDbContext : DbContext
{
    public DotnetServiceDbContext(DbContextOptions<DotnetServiceDbContext> options)
        : base(options) { }

    public DbSet<MorDbModel> Mors { get; set; }

    public DbSet<VikaDbModel> Vikas { get; set; }
}
