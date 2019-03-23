using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Models
{
    public class Show
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Duration { get; set; }

        [Required]
        public string Sponsor { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        //[Phone]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string ContactPhone { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}