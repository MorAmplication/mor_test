namespace DotnetService.APIs.Dtos;

public class VikaUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<string>? Mors { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
