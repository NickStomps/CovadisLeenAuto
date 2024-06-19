using System.ComponentModel.DataAnnotations;
using DemoCovadis.Shared.Dtos;

namespace DemoCovadis.Shared.Dtos
{
    public class RitDto
    {
        [Key]
        public int id { get; set; }

        public int AutoId { get; set; }

        [Required]
        public virtual AutoDto? auto { get; set; }
        [Required]
        public int kilometerGereden { get; set; }
        [Required]
        public UserDto? bestuurder { get; set; }
        [Required]
        public string beginAdres { get; set; }
        [Required]
        public string eindAdres { get; set; }
        [Required]
        public string vertrekTijd { get; set; }
        [Required]
        public string aankomstTijd { get; set; }
    }
}   

