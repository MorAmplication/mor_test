namespace DotnetService.APIs.Dtos;

public class CustomerDto : CustomerIdDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<OrderIdDto>? Orders { get; set; }
}
