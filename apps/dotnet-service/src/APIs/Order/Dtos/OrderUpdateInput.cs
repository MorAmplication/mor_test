namespace DotnetService.APIs.Dtos;

public class OrderUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public CustomerIdDto? Customer { get; set; }
}
