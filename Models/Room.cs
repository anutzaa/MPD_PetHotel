using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }

        [Display (Name = "Availability")]
        public bool isOccupied { get; set; }


        //foreign key
        [Display(Name = "Room Type")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [NotMapped]
        public string DisplayText
        {
            get
            {
                return $"{RoomNumber} - {Category?.CategoryName}";
            }
        }
    }
}
