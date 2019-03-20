using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Display(Name = "Breed")]
        [ForeignKey("Breed")]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("Ancestry")]
        public int? AncestryId { get; set; }
        public Ancestry Ancestry { get; set; }

        [Display(Name = "Attach Image")]
        public string ImagePath { get; set; }
    }
}