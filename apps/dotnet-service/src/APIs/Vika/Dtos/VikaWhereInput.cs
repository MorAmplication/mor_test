namespace DotnetService.APIs.Dtos;

public class VikaWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<string>? Mors { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
