using System.ComponentModel.DataAnnotations;
using AgendaApi.Entities;

namespace AgendaApi.Models.DTOs
{
    public class CreateContactDto
    {
        [Required]

        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }

        public string Description = string.Empty;

    }
}
