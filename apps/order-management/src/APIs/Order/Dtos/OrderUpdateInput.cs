namespace Order.APIs.Dtos;

public class OrderUpdateInput
{
    public string id { get; }

    public DateTime createdAt { get; }

    public string updatedAt { get; }

    public int? quantity { get; }

    public double? discount { get; }

    public int? totalPrice { get; }

    public CustomerDto? customer { get; }

    public ProductDto? product { get; }
}
