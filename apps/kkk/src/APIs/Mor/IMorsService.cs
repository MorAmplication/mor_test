using Kkk.APIs.Dtos;

namespace Kkk.APIs;

public interface IMorsService
{
    public Task<string> MorTest(Nn nnDto);
}
