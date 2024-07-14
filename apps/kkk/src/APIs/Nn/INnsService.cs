using Kkk.APIs.Common;
using Kkk.APIs.Dtos;

namespace Kkk.APIs;

public interface INnsService
{
    /// <summary>
    /// Create one nn
    /// </summary>
    public Task<Nn> CreateNn(NnCreateInput nn);

    /// <summary>
    /// Delete one nn
    /// </summary>
    public Task DeleteNn(NnWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many nns
    /// </summary>
    public Task<List<Nn>> Nns(NnFindManyArgs findManyArgs);

    /// <summary>
    /// Get one nn
    /// </summary>
    public Task<Nn> Nn(NnWhereUniqueInput uniqueId);
    public Task<string> MorAction(NnWhereInput nnWhereInputDto);

    /// <summary>
    /// Meta data about nn records
    /// </summary>
    public Task<MetadataDto> NnsMeta(NnFindManyArgs findManyArgs);

    /// <summary>
    /// Update one nn
    /// </summary>
    public Task UpdateNn(NnWhereUniqueInput uniqueId, NnUpdateInput updateDto);
}
