using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Models
{
    public class RegistrationModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nickname")]
        public string Login { get; set; }
        
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Password again")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string PasswordAgain { get; set; }
    }
}