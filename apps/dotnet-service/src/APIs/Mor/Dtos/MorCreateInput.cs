namespace DotnetService.APIs.Dtos;

public class MorCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Vika Vika { get; set; }
}
