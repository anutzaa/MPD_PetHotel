﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHotel.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Room type")]
        public string CategoryName { get; set; }

        [Display(Name = "Price per night")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        //nav property
        public ICollection<Room>? Rooms { get; set; }
    }
}
