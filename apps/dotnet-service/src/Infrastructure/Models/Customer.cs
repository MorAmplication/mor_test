using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetService.Infrastructure.Models;

[Table("Customers")]
public class Customer
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? FirstName { get; set; }

    [StringLength(1000)]
    public string? LastName { get; set; }

    public string? Email { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    public List<Order>? Orders { get; set; } = new List<Order>();

    public string AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    public Address? Address { get; set; } = null;
}
