using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Orders")]
public class Order
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public string UpdatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? Quantity { get; set; }

    [Range(-999999999, 999999999)]
    public double? Discount { get; set; }

    [Range(-999999999, 999999999)]
    public int? TotalPrice { get; set; }

    public string CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; } = null;

    public string ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; } = null;
}
