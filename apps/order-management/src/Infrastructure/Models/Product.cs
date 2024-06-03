using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Products")]
public class Product
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public string UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Range(-999999999, 999999999)]
    public double? ItemPrice { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public List<Order>? Orders { get; set; } = new List<Order>();
}
