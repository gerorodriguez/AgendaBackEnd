using System.ComponentModel.DataAnnotations;
using AgendaApi.Entities;

namespace AgendaApi.Models
{
    public class UpdateContactDto
    {
        [Required]

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CelularNumber { get; set; }

        public int? TelephoneNumber { get; set; }

        public string Description = string.Empty;


    }
}

