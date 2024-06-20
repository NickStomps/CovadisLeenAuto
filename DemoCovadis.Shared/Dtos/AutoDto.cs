using DemoCovadis.Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace DemoCovadis.Shared.Dtos;

public class AutoDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string kenteken { get; set; }
    [Required]
    public int kilometerStand { get; set; }
    public int laatsteBestuurderId { get; set; }
    public virtual List<RitDto>? rit { get; set; }
}