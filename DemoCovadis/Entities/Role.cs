using DemoCovadis.Entities;
using System.ComponentModel.DataAnnotations;

namespace DemoCovadis.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
