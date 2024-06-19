using DemoCovadis.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DemoCovadis.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Wachtwoord { get; set; }

        public virtual List<Role> Roles { get; set; } = new List<Role>();
    }
}
