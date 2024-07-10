using Kkk.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kkk.Infrastructure;

public class KkkDbContext : IdentityDbContext<IdentityUser>
{
    public KkkDbContext(DbContextOptions<KkkDbContext> options)
        : base(options) { }

    public DbSet<NnDbModel> Nns { get; set; }
}
