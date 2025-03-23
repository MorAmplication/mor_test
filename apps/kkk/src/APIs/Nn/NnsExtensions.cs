using Kkk.APIs.Dtos;
using Kkk.Infrastructure.Models;

namespace Kkk.APIs.Extensions;

public static class NnsExtensions
{
    public static Nn ToDto(this NnDbModel model)
    {
        return new Nn
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Njnj = model.Njnj,
        };
    }

    public static NnDbModel ToModel(this NnUpdateInput updateDto, NnWhereUniqueInput uniqueId)
    {
        var nn = new NnDbModel { Id = uniqueId.Id, Njnj = updateDto.Njnj };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            nn.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            nn.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return nn;
    }
}
