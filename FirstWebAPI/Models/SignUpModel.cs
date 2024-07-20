﻿using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI.Models
{
    public class SignUpModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ComfirmPassword { get; set; }
    }
}
