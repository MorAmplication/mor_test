using Kkk.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Kkk.APIs;

public class MorsService : MorsServiceBase
{
    public MorsService(KkkDbContext context)
        : base(context) { }
}
