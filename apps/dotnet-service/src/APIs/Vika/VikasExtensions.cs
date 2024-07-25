using DotnetService.APIs.Dtos;
using DotnetService.Infrastructure.Models;

namespace DotnetService.APIs.Extensions;

public static class VikasExtensions
{
    public static Vika ToDto(this VikaDbModel model)
    {
        return new Vika
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Mors = model.Mors?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VikaDbModel ToModel(this VikaUpdateInput updateDto, VikaWhereUniqueInput uniqueId)
    {
        var vika = new VikaDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            vika.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            vika.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return vika;
    }
}
