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
    /// Connect multiple Mors records to Vika
    /// </summary>
    public Task ConnectMors(VikaWhereUniqueInput uniqueId, MorWhereUniqueInput[] morsId);

    /// <summary>
    /// Disconnect multiple Mors records from Vika
    /// </summary>
    public Task DisconnectMors(VikaWhereUniqueInput uniqueId, MorWhereUniqueInput[] morsId);

    /// <summary>
    /// Find multiple Mors records for Vika
    /// </summary>
    public Task<List<Mor>> FindMors(VikaWhereUniqueInput uniqueId, MorFindManyArgs MorFindManyArgs);

    /// <summary>
    /// Meta data about Vika records
    /// </summary>
    public Task<MetadataDto> VikasMeta(VikaFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Mors records for Vika
    /// </summary>
    public Task UpdateMors(VikaWhereUniqueInput uniqueId, MorWhereUniqueInput[] morsId);
}
