using Microsoft.EntityFrameworkCore;
using Test_3.APIs;
using Test_3.APIs.Common;
using Test_3.APIs.Dtos;
using Test_3.APIs.Errors;
using Test_3.APIs.Extensions;
using Test_3.Infrastructure;
using Test_3.Infrastructure.Models;

namespace Test_3.APIs;

public abstract class TestsServiceBase : ITestsService
{
    protected readonly Test_3DbContext _context;

    public TestsServiceBase(Test_3DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Test
    /// </summary>
    public async Task<Test> CreateTest(TestCreateInput createDto)
    {
        var test = new TestDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            test.Id = createDto.Id;
        }

        _context.Tests.Add(test);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TestDbModel>(test.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Test
    /// </summary>
    public async Task DeleteTest(TestWhereUniqueInput uniqueId)
    {
        var test = await _context.Tests.FindAsync(uniqueId.Id);
        if (test == null)
        {
            throw new NotFoundException();
        }

        _context.Tests.Remove(test);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Tests
    /// </summary>
    public async Task<List<Test>> Tests(TestFindManyArgs findManyArgs)
    {
        var tests = await _context
            .Tests.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return tests.ConvertAll(test => test.ToDto());
    }

    /// <summary>
    /// Meta data about Test records
    /// </summary>
    public async Task<MetadataDto> TestsMeta(TestFindManyArgs findManyArgs)
    {
        var count = await _context.Tests.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Test
    /// </summary>
    public async Task<Test> Test(TestWhereUniqueInput uniqueId)
    {
        var tests = await this.Tests(
            new TestFindManyArgs { Where = new TestWhereInput { Id = uniqueId.Id } }
        );
        var test = tests.FirstOrDefault();
        if (test == null)
        {
            throw new NotFoundException();
        }

        return test;
    }

    /// <summary>
    /// Update one Test
    /// </summary>
    public async Task UpdateTest(TestWhereUniqueInput uniqueId, TestUpdateInput updateDto)
    {
        var test = updateDto.ToModel(uniqueId);

        _context.Entry(test).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tests.Any(e => e.Id == test.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<string> Create(TestFindManyArgs testFindManyArgsDto)
    {
        throw new NotImplementedException();
    }
}
