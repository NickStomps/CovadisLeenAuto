﻿using System.ComponentModel.DataAnnotations;
namespace DemoCovadis.Shared
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
