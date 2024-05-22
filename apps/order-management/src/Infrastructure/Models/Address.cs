namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Addresses")]
public class Address
{
    [Key()]
    [required()]
    public string id { get; }

    [required()]
    public DateTime createdAt { get; }

    [required()]
    public string updatedAt { get; }

    [StringLength(1000)]
    public string address_1 { get; }

    [StringLength(1000)]
    public string address_2 { get; }

    [StringLength(1000)]
    public string city { get; }

    [StringLength(1000)]
    public string state { get; }

    [Range(integer.MaxValue)]
    public int zip { get; }

    public List<Customer> customers { get; } = new List<Customer>();
}
