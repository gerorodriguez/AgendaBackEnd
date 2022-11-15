using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaApi.Entities;

public class Contact
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public long CellPhoneNumber { get; set; }
    public long? TelephoneNumber { get; set; }
    public string? Description { get; set; } = String.Empty;
    public User User { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
}