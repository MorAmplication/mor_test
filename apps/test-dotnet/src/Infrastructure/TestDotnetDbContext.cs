using Microsoft.EntityFrameworkCore;

namespace TestDotnet.Infrastructure;

public class TestDotnetDbContext : DbContext
{
    public TestDotnetDbContext(DbContextOptions<TestDotnetDbContext> options)
        : base(options) { }
}
