namespace DotnetService.APIs.Dtos;

public class ProductCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Name { get; set; }

    public double? ItemPrice { get; set; }

    public string? Description { get; set; }

    public List<OrderIdDto>? Orders { get; set; }
}
