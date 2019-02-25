using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Models
{
    public class Breed
    {
        public int BreedId { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public Breed()
        {
            Pets = new List<Pet>();
        }
    }
}