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
        public bool Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [ForeignKey("Breed")]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}