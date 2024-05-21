namespace Address.APIs.Dtos;

public class AddressCreateInput
{
    public string id { get; }

    public DateTime createdAt { get; }

    public string updatedAt { get; }

    public string? address_1 { get; }

    public string? address_2 { get; }

    public string? city { get; }

    public string? state { get; }

    public int? zip { get; }

    public List<CustomerDto>? customers { get; }
}
