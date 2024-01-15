﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PetHotel.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Pet Name")]
        public string PetName { get; set; }
        public string Species { get; set; }
  

        [Display(Name = "Age in months")]
        public int Age { get; set; }


        [Display(Name = "Special needs")]
        public bool hasSpecialNeeds { get; set; }

        //navigation property for Owner
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
