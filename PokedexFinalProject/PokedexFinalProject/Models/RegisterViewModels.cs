using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokedexFinalProject.Models
{
    public class RegisterViewModels
    {
        [Required]
        public string Name { get; set;}
        [Required]
        public string LastName { get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string DoB { get; set; }
        [Required]
        public string Username { get; set; }
    }
}