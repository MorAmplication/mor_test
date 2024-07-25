using DotnetService.APIs;
using DotnetService.APIs.Common;
using DotnetService.APIs.Dtos;
using DotnetService.APIs.Errors;
using DotnetService.APIs.Extensions;
using DotnetService.Infrastructure;
using DotnetService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetService.APIs;

public abstract class MorsServiceBase : IMorsService
{
    protected readonly DotnetServiceDbContext _context;

    public MorsServiceBase(DotnetServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Mor
    /// </summary>
    public async Task<Mor> CreateMor(MorCreateInput createDto)
    {
        var mor = new MorDbModel
        {
            Atest = createDto.Atest,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            mor.Id = createDto.Id;
        }
        if (createDto.Vika != null)
        {
            mor.Vika = await _context
                .Vikas.Where(vika => createDto.Vika.Id == vika.Id)
                .FirstOrDefaultAsync();
        }

        _context.Mors.Add(mor);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MorDbModel>(mor.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    public async Task<string> Customtest2(string data)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CustonTest(string data)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete one Mor
    /// </summary>
    public async Task DeleteMor(MorWhereUniqueInput uniqueId)
    {
        var mor = await _context.Mors.FindAsync(uniqueId.Id);
        if (mor == null)
        {
            throw new NotFoundException();
        }

        _context.Mors.Remove(mor);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Mors
    /// </summary>
    public async Task<List<Mor>> Mors(MorFindManyArgs findManyArgs)
    {
        var mors = await _context
            .Mors.Include(x => x.Vika)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return mors.ConvertAll(mor => mor.ToDto());
    }

    /// <summary>
    /// Get one Mor
    /// </summary>
    public async Task<Mor> Mor(MorWhereUniqueInput uniqueId)
    {
        var mors = await this.Mors(
            new MorFindManyArgs { Where = new MorWhereInput { Id = uniqueId.Id } }
        );
        var mor = mors.FirstOrDefault();
        if (mor == null)
        {
            throw new NotFoundException();
        }

        return mor;
    }

    /// <summary>
    /// Get a Vika record for Mor
    /// </summary>
    public async Task<Vika> GetVika(MorWhereUniqueInput uniqueId)
    {
        var mor = await _context
            .Mors.Where(mor => mor.Id == uniqueId.Id)
            .Include(mor => mor.Vika)
            .FirstOrDefaultAsync();
        if (mor == null)
        {
            throw new NotFoundException();
        }
        return mor.Vika.ToDto();
    }

    /// <summary>
    /// Meta data about Mor records
    /// </summary>
    public async Task<MetadataDto> MorsMeta(MorFindManyArgs findManyArgs)
    {
        var count = await _context.Mors.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Mor
    /// </summary>
    public async Task UpdateMor(MorWhereUniqueInput uniqueId, MorUpdateInput updateDto)
    {
        var mor = updateDto.ToModel(uniqueId);

        _context.Entry(mor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Mors.Any(e => e.Id == mor.Id))
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
