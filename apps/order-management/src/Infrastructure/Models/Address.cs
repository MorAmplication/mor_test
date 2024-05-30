using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementDotNet.Infrastructure.Models;

[Table("Addresses")]
public class Address
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public string UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? Address_1 { get; set; }

    [StringLength(1000)]
    public string? Address_2 { get; set; }

    [StringLength(1000)]
    public string? City { get; set; }

    [StringLength(1000)]
    public string? State { get; set; }

    [Range(optional.MaxValue)]
    public int? Zip { get; set; }

    public List<Customer>? Customers { get; set; } = new List<Customer>();
}
