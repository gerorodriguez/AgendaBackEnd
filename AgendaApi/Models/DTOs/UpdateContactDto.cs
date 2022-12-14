using System.ComponentModel.DataAnnotations;
using AgendaApi.Entities;

namespace AgendaApi.Models
{
    public class UpdateContactDto
    {
        [Required]

        public int Id { get; set; }
        public string Name { get; set; }
        public long? CellPhoneNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string? Description { get; set; }


    }
}

