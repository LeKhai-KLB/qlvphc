﻿using System.ComponentModel.DataAnnotations;

namespace IdentityService.Application.Common.Models.AuthModels
{
    public class AuthUser
    {
        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}