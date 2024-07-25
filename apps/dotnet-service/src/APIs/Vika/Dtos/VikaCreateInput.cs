namespace DotnetService.APIs.Dtos;

public class VikaCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<Mor>? Mors { get; set; }

    public DateTime UpdatedAt { get; set; }
}
