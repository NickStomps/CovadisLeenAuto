using System.ComponentModel.DataAnnotations;
namespace DemoCovadis.Shared
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
