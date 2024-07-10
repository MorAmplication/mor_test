using Microsoft.AspNetCore.Mvc;

namespace Kkk.APIs;

[ApiController()]
public class NnsController : NnsControllerBase
{
    public NnsController(INnsService service)
        : base(service) { }
}
