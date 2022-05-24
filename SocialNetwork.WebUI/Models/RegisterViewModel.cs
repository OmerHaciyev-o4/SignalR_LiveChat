﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public IFormFile File { get; set; }
        public string ImageUrl { get; set; } = "~/person.jpg";
    }
}
