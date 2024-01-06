﻿using System.ComponentModel.DataAnnotations;

namespace IdentityService.API.Models.UserModels
{
    public class RegisterUser
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }
    }
}