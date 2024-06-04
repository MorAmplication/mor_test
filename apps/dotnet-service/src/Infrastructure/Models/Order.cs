using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetService.Infrastructure.Models;

[Table("Orders")]
public class Order
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; } = null;
}
