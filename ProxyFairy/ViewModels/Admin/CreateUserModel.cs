﻿using System.ComponentModel.DataAnnotations;

namespace ProxyFairy.ViewModels.Admin
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
