using System.ComponentModel.DataAnnotations;

namespace Dotnet.APIs;

public class CustomerCustom
{
    [Required()]
    public string Name { get; set; }

    [Required()]
    public string Age { get; set; }

    [Required()]
    public string Address { get; set; }
}
