using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetService.Infrastructure.Models;

[Table("Vikas")]
public class VikaDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<MorDbModel>? Mors { get; set; } = new List<MorDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
