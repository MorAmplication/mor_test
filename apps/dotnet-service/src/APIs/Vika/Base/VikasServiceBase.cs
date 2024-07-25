using DotnetService.APIs;
using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;
using DotnetService.APIs.Errors;
using DotnetService.APIs.Extensions;
using DotnetService.Infrastructure;
using DotnetService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.APIs;

public abstract class VikasServiceBase : IVikasService
{
    protected readonly DotnetServiceDbContext _context;

    public VikasServiceBase(DotnetServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Vika
    /// </summary>
    public async Task<Vika> CreateVika(VikaCreateInput createDto)
    {
        var vika = new VikaDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            vika.Id = createDto.Id;
        }
        if (createDto.Mors != null)
        {
            vika.Mors = await _context
                .Mors.Where(mor => createDto.Mors.Select(t => t.Id).Contains(mor.Id))
                .ToListAsync();
        }

        _context.Vikas.Add(vika);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VikaDbModel>(vika.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Vika
    /// </summary>
    public async Task DeleteVika(VikaWhereUniqueInput uniqueId)
    {
        var vika = await _context.Vikas.FindAsync(uniqueId.Id);
        if (vika == null)
        {
            throw new NotFoundException();
        }

        _context.Vikas.Remove(vika);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Vikas
    /// </summary>
    public async Task<List<Vika>> Vikas(VikaFindManyArgs findManyArgs)
    {
        var vikas = await _context
            .Vikas.Include(x => x.Mors)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return vikas.ConvertAll(vika => vika.ToDto());
    }

    /// <summary>
    /// Get one Vika
    /// </summary>
    public async Task<Vika> Vika(VikaWhereUniqueInput uniqueId)
    {
        var vikas = await this.Vikas(
            new VikaFindManyArgs { Where = new VikaWhereInput { Id = uniqueId.Id } }
        );
        var vika = vikas.FirstOrDefault();
        if (vika == null)
        {
            throw new NotFoundException();
        }

        return vika;
    }

    /// <summary>
    /// Update one Vika
    /// </summary>
    public async Task UpdateVika(VikaWhereUniqueInput uniqueId, VikaUpdateInput updateDto)
    {
        var vika = updateDto.ToModel(uniqueId);

        if (updateDto.Mors != null)
        {
            vika.Mors = await _context
                .Mors.Where(mor => updateDto.Mors.Select(t => t).Contains(mor.Id))
                .ToListAsync();
        }

        _context.Entry(vika).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Vikas.Any(e => e.Id == vika.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Mors records to Vika
    /// </summary>
    public async Task ConnectMors(VikaWhereUniqueInput uniqueId, MorWhereUniqueInput[] morsId)
    {
        var vika = await _context
            .Vikas.Include(x => x.Mors)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (vika == null)
        {
            throw new NotFoundException();
        }

        var mors = await _context
            .Mors.Where(t => morsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (mors.Count == 0)
        {
            throw new NotFoundException();
        }

        var morsToConnect = mors.Except(vika.Mors);

        foreach (var mor in morsToConnect)
        {
            vika.Mors.Add(mor);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Mors records from Vika
    /// </summary>
    public async Task DisconnectMors(VikaWhereUniqueInput uniqueId, MorWhereUniqueInput[] morsId)
    {
        var vika = await _context
            .Vikas.Include(x => x.Mors)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (vika == null)
        {
            throw new NotFoundException();
        }

        var mors = await _context
            .Mors.Where(t => morsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var mor in mors)
        {
            vika.Mors?.Remove(mor);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Mors records for Vika
    /// </summary>
    public async Task<List<Mor>> FindMors(
        VikaWhereUniqueInput uniqueId,
        MorFindManyArgs vikaFindManyArgs
    )
    {
        var mors = await _context
            .Mors.Where(m => m.VikaId == uniqueId.Id)
            .ApplyWhere(vikaFindManyArgs.Where)
            .ApplySkip(vikaFindManyArgs.Skip)
            .ApplyTake(vikaFindManyArgs.Take)
            .ApplyOrderBy(vikaFindManyArgs.SortBy)
            .ToListAsync();

        return mors.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Meta data about Vika records
    /// </summary>
    public async Task<MetadataDto> VikasMeta(VikaFindManyArgs findManyArgs)
    {
        var count = await _context.Vikas.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Mors records for Vika
    /// </summary>
    public async Task UpdateMors(VikaWhereUniqueInput uniqueId, MorWhereUniqueInput[] morsId)
    {
        var vika = await _context
            .Vikas.Include(t => t.Mors)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (vika == null)
        {
            throw new NotFoundException();
        }

        var mors = await _context
            .Mors.Where(a => morsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (mors.Count == 0)
        {
            throw new NotFoundException();
        }

        vika.Mors = mors;
        await _context.SaveChangesAsync();
    }
}
