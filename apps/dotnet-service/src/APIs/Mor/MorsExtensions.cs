using DotnetService.APIs.Dtos;
using DotnetService.Infrastructure.Models;

namespace DotnetService.APIs.Extensions;

public static class MorsExtensions
{
    public static Mor ToDto(this MorDbModel model)
    {
        return new Mor
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            Vika = model.VikaId,
        };
    }

    public static MorDbModel ToModel(this MorUpdateInput updateDto, MorWhereUniqueInput uniqueId)
    {
        var mor = new MorDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            mor.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            mor.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Vika != null)
        {
            mor.Vika = updateDto.Vika;
        }

        return mor;
    }
}
