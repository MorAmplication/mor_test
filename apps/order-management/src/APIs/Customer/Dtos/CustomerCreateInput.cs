namespace Customer.APIs.Dtos;

public class CustomerCreateInput
{
    public string id { get; }

    public DateTime createdAt { get; }

    public string updatedAt { get; }

    public string? firstName { get; }

    public string? lastName { get; }

    public string? email { get; }

    public string? phone { get; }

    public List<OrderDto>? orders { get; }

    public AddressDto? address { get; }
}
