using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Models
{
    public class Breeder
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Web Site")]
        [Url]
        public string WebSite { get; set; }

        [ForeignKey("Login")]
        public int LoginId { get; set; }
        public Login Login { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }


    }
}