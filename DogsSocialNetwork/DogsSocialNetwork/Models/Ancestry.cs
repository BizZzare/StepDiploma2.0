using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Models
{
    public class Ancestry
    {
        public int Id { get; set; }

        [ForeignKey("Mother")]
        [Display(Name = "Mother")]
        public int? MotherId { get; set; }
        public Pet Mother { get; set; }

        [ForeignKey("Father")]
        [Display(Name = "Father")]
        public int? FatherId { get; set; }
        public Pet Father { get; set; }

        [Display(Name = "Attach Document")]
        public string DocumentPath { get; set; }
    }
}