using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetService.Infrastructure.Models;

[Table("Mors")]
public class MorDbModel
{
    [StringLength(1000)]
    public string? Atest { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string VikaId { get; set; }

    [ForeignKey(nameof(VikaId))]
    public VikaDbModel Vika { get; set; } = null;
}
