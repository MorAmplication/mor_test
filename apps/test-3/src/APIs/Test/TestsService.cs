using Test_3.Infrastructure;

namespace Test_3.APIs;

public class TestsService : TestsServiceBase
{
    public TestsService(Test_3DbContext context)
        : base(context) { }
}
