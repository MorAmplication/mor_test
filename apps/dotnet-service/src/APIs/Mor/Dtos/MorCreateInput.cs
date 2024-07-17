namespace DotnetService.APIs.Dtos;

public class MorCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Vika Vika { get; set; }
}
