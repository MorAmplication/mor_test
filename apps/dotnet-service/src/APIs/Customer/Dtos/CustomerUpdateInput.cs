namespace DotnetService.APIs.Dtos;

public class CustomerUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<OrderIdDto>? Orders { get; set; }
}
