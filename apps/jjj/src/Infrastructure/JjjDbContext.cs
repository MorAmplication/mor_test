using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jjj.Infrastructure;

public class JjjDbContext : IdentityDbContext<IdentityUser>
{
    public JjjDbContext(DbContextOptions<JjjDbContext> options)
        : base(options) { }
}
