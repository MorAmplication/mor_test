namespace Product.APIs.Dtos;

public class ProductUpdateInput
{
    public string id { get; }

    public DateTime createdAt { get; }

    public string updatedAt { get; }

    public string? name { get; }

    public double? itemPrice { get; }

    public string? description { get; }

    public List<OrderDto>? orders { get; }
}
