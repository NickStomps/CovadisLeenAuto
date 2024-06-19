using System.ComponentModel.DataAnnotations;
namespace DemoCovadis.Shared.Dtos
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Email { get; set; }

        public List<string> Roles { get; set; } = new List<string>(); 
    }
}
