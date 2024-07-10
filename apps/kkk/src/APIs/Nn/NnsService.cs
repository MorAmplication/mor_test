using Kkk.Infrastructure;

namespace Kkk.APIs;

public class NnsService : NnsServiceBase
{
    public NnsService(KkkDbContext context)
        : base(context) { }
}
