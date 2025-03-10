﻿using System.ComponentModel.DataAnnotations;

namespace IdentityService.Application.Common.Models.AuthModels
{
    public class ResetPasswordModel
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        //[Required]
        //public string Token { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}