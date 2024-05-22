namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Orders")]
public class Order
{
    [Key()]
    [required()]
    public string id { get; }

    [required()]
    public DateTime createdAt { get; }

    [required()]
    public string updatedAt { get; }

    [Range(integer.MaxValue)]
    public int quantity { get; }

    [Range(double.MaxValue)]
    public double discount { get; }

    [Range(integer.MaxValue)]
    public int totalPrice { get; }

    public Customer customerId { get; }

    [ForeignKey(nameof(customerId))]
    public Customer customer { get; } = null;

    public Product productId { get; }

    [ForeignKey(nameof(productId))]
    public Product product { get; } = null;
}
