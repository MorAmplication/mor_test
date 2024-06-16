using Dotnet.APIs.Dtos;

namespace Dotnet.APIs;

public interface IMorsService
{
    public Task<CustomerCustom> CreateMor(string data);
}
