using Microsoft.EntityFrameworkCore;
using Test_3.Infrastructure.Models;

namespace Test_3.Infrastructure;

public class Test_3DbContext : DbContext
{
    public Test_3DbContext(DbContextOptions<Test_3DbContext> options)
        : base(options) { }

    public DbSet<TestDbModel> Tests { get; set; }
}
