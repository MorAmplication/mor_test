namespace DotnetService.APIs.Dtos;

public class AddressDto : AddressIdDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Address_1 { get; set; }

    public string? Address_2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? Zip { get; set; }

    public List<CustomerIdDto>? Customers { get; set; }
}
