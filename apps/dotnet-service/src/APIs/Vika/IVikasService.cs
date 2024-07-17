using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;

namespace DotnetService.APIs;

public interface IVikasService
{
    /// <summary>
    /// Create one Vika
    /// </summary>
    public Task<Vika> CreateVika(VikaCreateInput vika);

    /// <summary>
    /// Delete one Vika
    /// </summary>
    public Task DeleteVika(VikaWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Vikas
    /// </summary>
    public Task<List<Vika>> Vikas(VikaFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Vika
    /// </summary>
    public Task<Vika> Vika(VikaWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Vika
    /// </summary>
    public Task UpdateVika(VikaWhereUniqueInput uniqueId, VikaUpdateInput updateDto);

    /// <summary>
    /// Meta data about Vika records
    /// </summary>
    public Task<MetadataDto> VikasMeta(VikaFindManyArgs findManyArgs);
}
