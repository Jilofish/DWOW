using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DWOW.Models;

[Table("Creds")]
public class Credential
{
    [Key]
    public int ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
