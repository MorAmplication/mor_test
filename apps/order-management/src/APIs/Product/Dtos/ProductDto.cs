namespace Product.APIs.Dtos;

public class ProductDto : ProductIdDto
{
    public DateTime createdAt { get; }

    public string updatedAt { get; }

    public string? name { get; }

    public double? itemPrice { get; }

    public string? description { get; }

    public List<OrderDto>? orders { get; }
}
