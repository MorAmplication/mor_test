using Kkk.APIs;
using Kkk.Infrastructure;
using Kkk.Infrastructure.Models;

namespace Kkk.APIs;

public abstract class MorsServiceBase : IMorsService
{
    protected readonly KkkDbContext _context;

    public MorsServiceBase(KkkDbContext context)
    {
        _context = context;
    }
}
