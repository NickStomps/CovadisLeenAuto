using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DemoCovadis.Shared.Requests;

public class UserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Wachtwoord { get; set; }

    [Required]
    public string Naam { get; set; }
}