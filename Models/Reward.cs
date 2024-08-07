using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DWOW.Models;

[Table("Reward")]
public class Reward
{
    [Key]
    public int Id { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Points { get; set; }
    public string? ImageUrl { get; set; }
    public int Quantity { get; set; }
}
