namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Products")]
public class Product
{
    [Key()]
    [required()]
    public string id { get; }

    [required()]
    public DateTime createdAt { get; }

    [required()]
    public string updatedAt { get; }

    [StringLength(1000)]
    public string name { get; }

    [Range(double.MaxValue)]
    public double itemPrice { get; }

    [StringLength(1000)]
    public string description { get; }

    public List<Order> orders { get; } = new List<Order>();
}
