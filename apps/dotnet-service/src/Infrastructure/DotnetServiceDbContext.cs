using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.Infrastructure;

public class DotnetServiceDbContext : IdentityDbContext<IdentityUser>
{
    public DotnetServiceDbContext(DbContextOptions<DotnetServiceDbContext> options)
        : base(options) { }
}
