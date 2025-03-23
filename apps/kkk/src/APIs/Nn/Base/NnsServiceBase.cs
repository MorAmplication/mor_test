using Kkk.APIs;
using Kkk.APIs.Common;
using Kkk.APIs.Dtos;
using Kkk.APIs.Errors;
using Kkk.APIs.Extensions;
using Kkk.Infrastructure;
using Kkk.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Kkk.APIs;

public abstract class NnsServiceBase : INnsService
{
    protected readonly KkkDbContext _context;

    public NnsServiceBase(KkkDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one nn
    /// </summary>
    public async Task<Nn> CreateNn(NnCreateInput createDto)
    {
        var nn = new NnDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Njnj = createDto.Njnj
        };

        if (createDto.Id != null)
        {
            nn.Id = createDto.Id;
        }

        _context.Nns.Add(nn);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<NnDbModel>(nn.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one nn
    /// </summary>
    public async Task DeleteNn(NnWhereUniqueInput uniqueId)
    {
        var nn = await _context.Nns.FindAsync(uniqueId.Id);
        if (nn == null)
        {
            throw new NotFoundException();
        }

        _context.Nns.Remove(nn);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many nns
    /// </summary>
    public async Task<List<Nn>> Nns(NnFindManyArgs findManyArgs)
    {
        var nns = await _context
            .Nns.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return nns.ConvertAll(nn => nn.ToDto());
    }

    /// <summary>
    /// Get one nn
    /// </summary>
    public async Task<Nn> Nn(NnWhereUniqueInput uniqueId)
    {
        var nns = await this.nns(
            new NnFindManyArgs { Where = new NnWhereInput { Id = uniqueId.Id } }
        );
        var nn = nns.FirstOrDefault();
        if (nn == null)
        {
            throw new NotFoundException();
        }

        return nn;
    }

    public async Task<string> MorAction(NnWhereInput nnWhereInputDto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Meta data about nn records
    /// </summary>
    public async Task<MetadataDto> NnsMeta(NnFindManyArgs findManyArgs)
    {
        var count = await _context.Nns.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one nn
    /// </summary>
    public async Task UpdateNn(NnWhereUniqueInput uniqueId, NnUpdateInput updateDto)
    {
        var nn = updateDto.ToModel(uniqueId);

        _context.Entry(nn).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Nns.Any(e => e.Id == nn.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
