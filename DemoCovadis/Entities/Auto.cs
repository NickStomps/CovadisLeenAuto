using CovadisAPI.Entities;
using System.ComponentModel.DataAnnotations;
namespace DemoCovadis.Entities
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string kenteken { get; set; }
        [Required]
        public int beginStandKm { get; set; }
        [Required]
        public int eindStandKm { get; set; }
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