using Microsoft.AspNetCore.Mvc;

namespace Test_3.APIs;

[ApiController()]
public class TestsController : TestsControllerBase
{
    public TestsController(ITestsService service)
        : base(service) { }
}
