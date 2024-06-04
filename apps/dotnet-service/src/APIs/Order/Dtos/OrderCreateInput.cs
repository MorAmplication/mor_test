namespace DotnetService.APIs.Dtos;

public class OrderCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? Quantity { get; set; }

    public double? Discount { get; set; }

    public int? TotalPrice { get; set; }

    public CustomerIdDto? Customer { get; set; }

    public ProductIdDto? Product { get; set; }
}
