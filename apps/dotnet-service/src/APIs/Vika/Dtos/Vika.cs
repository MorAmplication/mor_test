namespace DotnetService.APIs.Dtos;

public class Vika
{
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<string>? Mors { get; set; }
}
