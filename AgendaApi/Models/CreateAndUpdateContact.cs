using System.ComponentModel.DataAnnotations;
using AgendaApi.Entities;

namespace AgendaApi.Models
{
    public class CreateAndUpdateContact
    {
        [Required]
        
        public string Name { get; set; }
        public int? CelularNumber { get; set; }

        public int? TelephoneNumber  { get; set; }

        public string Description = string.Empty;

        public User? User;

    }
}
