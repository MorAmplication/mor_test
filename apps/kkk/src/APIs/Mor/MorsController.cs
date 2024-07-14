using Kkk.APIs;
using Microsoft.AspNetCore.Mvc;

namespace Kkk.APIs;

[ApiController()]
public class MorsController : MorsControllerBase
{
    public MorsController(IMorsService service)
        : base(service) { }
}
