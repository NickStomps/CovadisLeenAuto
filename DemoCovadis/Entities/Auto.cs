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
        public int kilometerStand { get; set; }
        public User? laatsteBestuurder { get; set; }
        public virtual  List<Rit>? rit { get; set; }
    }
}