namespace OrderManagementDotNet.APIs.Dtos;

public class CustomerUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedAt { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public List<OrderIdDto>? Orders { get; set; }

    public AddressIdDto? Address { get; set; }
}
