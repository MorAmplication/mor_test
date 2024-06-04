namespace DotnetService.APIs.Dtos;

public class OrderDto : OrderIdDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public CustomerIdDto? Customer { get; set; }
}
