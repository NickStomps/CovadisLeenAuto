using CovadisAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace DemoCovadis.Entities
{
    public class Rit
    {
        [Key]
        public int id { get; set; }
        [Required]
        public Auto? auto { get; set; }
        [Required]
        public int kilometerGereden { get; set; }
        [Required]
        public User? bestuurder { get; set; }
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
