using System.ComponentModel.DataAnnotations;
using AgendaApi.Entities;

namespace AgendaApi.Models.DTOs
{
    public class CreateContactDto
    {
        [Required]
        public string Name { get; set; }
        public long? CellPhoneNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string? Description { get; set; }
    }
}
