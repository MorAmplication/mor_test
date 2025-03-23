using Dotnet.APIs;
using Dotnet.APIs.Dtos;
using Dotnet.Infrastructure;
using Dotnet.Infrastructure.Models;

namespace Dotnet.APIs;

public abstract class MorsServiceBase : IMorsService
{
    protected readonly DotnetDbContext _context;

    public MorsServiceBase(DotnetDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerCustom> CreateMor(string data)
    {
        throw new NotImplementedException();
    }
}
