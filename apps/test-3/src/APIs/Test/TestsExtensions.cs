using Test_3.APIs.Dtos;
using Test_3.Infrastructure.Models;

namespace Test_3.APIs.Extensions;

public static class TestsExtensions
{
    public static Test ToDto(this TestDbModel model)
    {
        return new Test
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TestDbModel ToModel(this TestUpdateInput updateDto, TestWhereUniqueInput uniqueId)
    {
        var test = new TestDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            test.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            test.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return test;
    }
}
