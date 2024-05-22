namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Customers")]
public class Customer
{
    [Key()]
    [required()]
    public string id { get; }

    [required()]
    public DateTime createdAt { get; }

    [required()]
    public string updatedAt { get; }

    [StringLength(1000)]
    public string firstName { get; }

    [StringLength(1000)]
    public string lastName { get; }

    public string email { get; }

    [StringLength(1000)]
    public string phone { get; }

    public List<Order> orders { get; } = new List<Order>();

    public Address addressId { get; }

    [ForeignKey(nameof(addressId))]
    public Address address { get; } = null;
}
