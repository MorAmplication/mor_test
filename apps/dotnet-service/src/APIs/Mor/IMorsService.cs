using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;

namespace DotnetService.APIs;

public interface IMorsService
{
    /// <summary>
    /// Create one Mor
    /// </summary>
    public Task<Mor> CreateMor(MorCreateInput mor);
    public Task<string> Customtest2(string data);
    public Task<string> CustonTest(string data);

    /// <summary>
    /// Delete one Mor
    /// </summary>
    public Task DeleteMor(MorWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Mors
    /// </summary>
    public Task<List<Mor>> Mors(MorFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Mor
    /// </summary>
    public Task<Mor> Mor(MorWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Vika record for Mor
    /// </summary>
    public Task<Vika> GetVika(MorWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Mor records
    /// </summary>
    public Task<MetadataDto> MorsMeta(MorFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Mor
    /// </summary>
    public Task UpdateMor(MorWhereUniqueInput uniqueId, MorUpdateInput updateDto);
}
